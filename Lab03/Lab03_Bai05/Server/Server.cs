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

            Log("✅ Server khởi tạo xong!");
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
                Log($"❌ Lỗi tải danh sách: {ex.Message}");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, PORT);
            _listener.Start();

            Log($"🟢 Server lắng nghe tại 127.0.0.1:{PORT}");
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

            Log("⛔ Server đã dừng");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private async Task AcceptClientsAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                _clients.Add(client);
                Log($"✅ Client kết nối: {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client, token);
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[10240];

            while (!token.IsCancellationRequested && client.Connected)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                if (bytesRead == 0) break;

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                if (!string.IsNullOrEmpty(message))
                    HandleMessage(message, stream);
            }

            stream.Close();
            client.Close();
            _clients.Remove(client);
            Log("Client ngắt kết nối");
        }

        private void HandleMessage(string json, NetworkStream stream)
        {
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                string action = doc.RootElement.GetProperty("action").GetString();
                if (action == "AddFood")
                {
                    var data = doc.RootElement.GetProperty("data");
                    string ten = data.GetProperty("TenMonAn").GetString();
                    string hinh = data.GetProperty("HinhAnh").GetString();
                    string nguoi = data.GetProperty("NguoiDang").GetString();
                    string quyen = data.GetProperty("QuyenHan").GetString();

                    string storedPath = hinh;
                    if (File.Exists(hinh))
                    {
                        string destPath = Path.Combine(_imageFolder, Path.GetFileName(hinh));
                        File.Copy(hinh, destPath, true);
                        storedPath = destPath;
                    }

                    int idNcc = DatabaseHelper.AddOrGetUser(_dbPath, nguoi, quyen);
                    DatabaseHelper.AddFood(_dbPath, ten, storedPath, idNcc);

                    Log($"✅ Đã thêm món: {ten} của {nguoi}");
                    Invoke(new Action(() => LoadFoodsToListView()));
                    BroadcastUpdateToAllClients();
                }
                else if (action == "GetFoods")
                {
                    SendFoodsToClient(stream);
                }
            }
        }

        private void SendFoodsToClient(NetworkStream stream)
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
                        foodList.Add(new
                        {
                            IDMA = reader.GetInt32(0),
                            TenMonAn = reader[1]?.ToString() ?? "",
                            NguoiDang = reader[2]?.ToString() ?? "N/A",
                            QuyenHan = reader[3]?.ToString() ?? "N/A",
                            HinhAnh = reader[4]?.ToString() ?? ""
                        });
                    }
                }
            }

            var payload = new { action = "UpdateFoods", foods = foodList };
            string jsonResponse = JsonSerializer.Serialize(payload) + "\n";
            byte[] data = Encoding.UTF8.GetBytes(jsonResponse);
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }

        private void BroadcastUpdateToAllClients()
        {
            var payload = new { action = "UpdateFoods", foods = new List<object>() };
            string json = JsonSerializer.Serialize(payload) + "\n";
            byte[] data = Encoding.UTF8.GetBytes(json);

            foreach (var client in _clients)
            {
                if (client.Connected)
                    client.GetStream().Write(data, 0, data.Length);
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
