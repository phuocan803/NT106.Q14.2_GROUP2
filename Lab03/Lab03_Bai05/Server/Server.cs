using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai05.Shared;

namespace Bai05.Server
{
    public partial class ServerForm : Form
    {
        private TcpListener _listener;
        private List<TcpClient> _clients = new List<TcpClient>();
        private CancellationTokenSource _cts;

        private string _dbPath;
        private string _imageFolder;
        private const int PORT = 5000;

        public ServerForm()
        {
            InitializeComponent();

            _dbPath = Path.Combine(AppContext.BaseDirectory, "food_server.db");
            _imageFolder = Path.Combine(AppContext.BaseDirectory, "ServerImages");

            if (!Directory.Exists(_imageFolder))
                Directory.CreateDirectory(_imageFolder);

            DatabaseHelper.InitializeDatabase(_dbPath);

            SetupListView();
            LoadFoodsToListView();

            Log("Server khởi tạo xong!");
        }

        private void SetupListView()
        {
            listViewFoods.View = View.Details;
            listViewFoods.FullRowSelect = true;
            listViewFoods.GridLines = true;
            listViewFoods.Columns.Clear();
            listViewFoods.Columns.Add("ID", 50);
            listViewFoods.Columns.Add("Tên món", 150);
            listViewFoods.Columns.Add("Người đăng", 120);
            listViewFoods.Columns.Add("Quyền hạn", 100);
            listViewFoods.Columns.Add("Ảnh", 200);
        }

        private void LoadFoodsToListView()
        {
            try
            {
                listViewFoods.Items.Clear();

                string connString = $"Data Source={_dbPath};Version=3;";
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT m.IDMA, m.TenMon, n.HoVaTen, n.QuyenHan, m.HinhAnh
                                   FROM MonAn m
                                   LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                                   ORDER BY m.IDMA";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader[0].ToString());
                            item.SubItems.Add(reader[1]?.ToString() ?? "");
                            item.SubItems.Add(reader[2]?.ToString() ?? "N/A");
                            item.SubItems.Add(reader[3]?.ToString() ?? "N/A");
                            item.SubItems.Add(Path.GetFileName(reader[4]?.ToString() ?? ""));
                            listViewFoods.Items.Add(item);
                        }
                    }
                }

                Log($"Đã tải {listViewFoods.Items.Count} món ăn");
            }
            catch (Exception ex)
            {
                Log($"Lỗi tải danh sách: {ex.Message}");
            }
        }


        private string GetLocalIPAddress()
        {
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                List<string> ips = new List<string>();

                foreach (var ip in host.AddressList)
                {
                    string ipStr = ip.ToString();
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                        && !ipStr.StartsWith("127.")
                        && !ipStr.StartsWith("192.168.56."))
                    {
                        ips.Add(ipStr);
                    }
                }

                return ips.Count > 0 ? string.Join(", ", ips) : "Không tìm thấy IP";
            }
            catch { }
            return "Không tìm thấy IP";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, PORT);
            _listener.Start();

            string allIPs = GetLocalIPAddress();

            Log($"SERVER ĐANG CHẠY");
            Log($"Các IP có sẵn:");

            foreach (var ip in allIPs.Split(new[] { ", " }, StringSplitOptions.None))
            {
                Log($"   • {ip}:{PORT}");
            }

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            Task.Run(() => AcceptClientsAsync(_cts.Token));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _listener?.Stop();
            foreach (var client in _clients) client.Close();
            _clients.Clear();

            Log("Server đã dừng");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private async Task AcceptClientsAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                _clients.Add(client);
                Log($"Client kết nối: {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client, token);
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            NetworkStream stream = client.GetStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 1024, leaveOpen: true))
            {
                while (!token.IsCancellationRequested && client.Connected)
                {
                    string line = await reader.ReadLineAsync();
                    if (line == null) break;
                    if (!string.IsNullOrWhiteSpace(line))
                        HandleMessage(line, stream);
                }
            }

            stream.Close();
            client.Close();
            _clients.Remove(client);
            Log("Client ngắt kết nối");
        }

        // XỬ LÝ TIN NHẮN VÀ NHẬN ẢNH BASE64
        private void HandleMessage(string json, NetworkStream stream)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    string action = doc.RootElement.GetProperty("action").GetString();

                    if (action == "AddFood")
                    {
                        var data = doc.RootElement.GetProperty("data");
                        string ten = data.GetProperty("TenMonAn").GetString();
                        string base64Image = data.GetProperty("HinhAnh").GetString(); // Nhận Base64
                        string nguoi = data.GetProperty("NguoiDang").GetString();
                        string quyen = data.GetProperty("QuyenHan").GetString();

                        // LƯU ẢNH BASE64 VÀO FILE
                        string imageFileName = SaveBase64ImageToFile(base64Image, ten);

                        // LƯU VÀO DATABASE
                        int idNcc = DatabaseHelper.AddOrGetUser(_dbPath, nguoi, quyen);
                        DatabaseHelper.AddFood(_dbPath, ten, imageFileName, idNcc);

                        Log($"Đã thêm món: {ten} của {nguoi}");
                        Invoke(new Action(() => LoadFoodsToListView()));

                        // GỬI CẬP NHẬT CHO TẤT CẢ CLIENT
                        BroadcastUpdateToAllClients();
                    }
                    else if (action == "GetFoods")
                    {
                        SendFoodsToClient(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Lỗi xử lý tin nhắn: {ex.Message}");
            }
        }

        // LƯU ẢNH BASE64 VÀO FILE
        private string SaveBase64ImageToFile(string base64Image, string tenMon)
        {
            try
            {
                if (string.IsNullOrEmpty(base64Image))
                    return "";

                // Tạo tên file duy nhất
                string fileName = $"{DateTime.Now.Ticks}_{tenMon.Replace(" ", "_")}.jpg";
                string fullPath = Path.Combine(_imageFolder, fileName);

                // Chuyển Base64 thành byte[] và lưu
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                File.WriteAllBytes(fullPath, imageBytes);

                Log($"Đã lưu ảnh: {fileName}");
                return fileName; // Chỉ lưu tên file vào DB
            }
            catch (Exception ex)
            {
                Log($"Lỗi lưu ảnh: {ex.Message}");
                return "";
            }
        }

        // GỬI DANH SÁCH MÓN ĂN VỚI ẢNH BASE64
        private void SendFoodsToClient(NetworkStream stream)
        {
            try
            {
                var foodList = new List<object>();
                string connString = $"Data Source={_dbPath};Version=3;";

                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT m.IDMA, m.TenMon, n.HoVaTen, n.QuyenHan, m.HinhAnh
                                   FROM MonAn m
                                   LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                                   ORDER BY m.IDMA";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imageFileName = reader[4]?.ToString() ?? "";
                            string base64Image = "";

                            // CHUYỂN ẢNH THÀNH BASE64
                            if (!string.IsNullOrEmpty(imageFileName))
                            {
                                string fullPath = Path.Combine(_imageFolder, imageFileName);
                                if (File.Exists(fullPath))
                                {
                                    base64Image = ImageToBase64(fullPath);
                                }
                            }

                            foodList.Add(new
                            {
                                IDMA = reader.GetInt32(0),
                                TenMonAn = reader[1]?.ToString() ?? "",
                                NguoiDang = reader[2]?.ToString() ?? "N/A",
                                QuyenHan = reader[3]?.ToString() ?? "N/A",
                                HinhAnh = base64Image // Gửi Base64
                            });
                        }
                    }
                }

                var payload = new { action = "UpdateFoods", foods = foodList };
                string jsonResponse = JsonSerializer.Serialize(payload) + "\n";
                byte[] data = Encoding.UTF8.GetBytes(jsonResponse);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                Log($"Đã gửi {foodList.Count} món ăn cho client");
            }
            catch (Exception ex)
            {
                Log($"Lỗi gửi danh sách: {ex.Message}");
            }
        }

        // BROADCAST CẬP NHẬT CHO TẤT CẢ CLIENT
        private void BroadcastUpdateToAllClients()
        {
            try
            {
                var foodList = new List<object>();
                string connString = $"Data Source={_dbPath};Version=3;";

                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT m.IDMA, m.TenMon, n.HoVaTen, n.QuyenHan, m.HinhAnh
                                   FROM MonAn m
                                   LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                                   ORDER BY m.IDMA";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imageFileName = reader[4]?.ToString() ?? "";
                            string base64Image = "";

                            if (!string.IsNullOrEmpty(imageFileName))
                            {
                                string fullPath = Path.Combine(_imageFolder, imageFileName);
                                if (File.Exists(fullPath))
                                {
                                    base64Image = ImageToBase64(fullPath);
                                }
                            }

                            foodList.Add(new
                            {
                                IDMA = reader.GetInt32(0),
                                TenMonAn = reader[1]?.ToString() ?? "",
                                NguoiDang = reader[2]?.ToString() ?? "N/A",
                                QuyenHan = reader[3]?.ToString() ?? "N/A",
                                HinhAnh = base64Image
                            });
                        }
                    }
                }

                var payload = new { action = "UpdateFoods", foods = foodList };
                string json = JsonSerializer.Serialize(payload) + "\n";
                byte[] data = Encoding.UTF8.GetBytes(json);

                foreach (var client in _clients.ToArray()) // ToArray() để tránh lỗi collection modified
                {
                    try
                    {
                        if (client.Connected)
                        {
                            client.GetStream().Write(data, 0, data.Length);
                            client.GetStream().Flush();
                        }
                    }
                    catch
                    {
                        // Client đã ngắt kết nối
                    }
                }

                Log($"Đã broadcast {foodList.Count} món ăn");
            }
            catch (Exception ex)
            {
                Log($"Lỗi broadcast: {ex.Message}");
            }
        }

        // CHUYỂN ẢNH THÀNH BASE64
        private string ImageToBase64(string path)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return "";
            }
        }

        private void Log(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(Log), message);
                return;
            }
            richTextBoxLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
        }
    }
}