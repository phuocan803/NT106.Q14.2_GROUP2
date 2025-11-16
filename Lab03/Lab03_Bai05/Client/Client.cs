using Bai05.Shared;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class ClientForm : Form
    {
        private List<(string ten, string nguoi, string quyen, string hinh)> _myFoods = new List<(string, string, string, string)>();
        private List<FoodItem> _communityFoods = new List<FoodItem>();

        private string _selectedImagePath = "";
        private string _dbPath;
        private string _imageFolder;

        private TcpClient _tcpClient;
        private NetworkStream _ns;
        private CancellationTokenSource _cts;

        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 5000;

        public ClientForm()
        {
            InitializeComponent();

            _dbPath = Path.Combine(AppContext.BaseDirectory, "food_client.db");
            _imageFolder = Path.Combine(AppContext.BaseDirectory, "ClientImages");

            if (!Directory.Exists(_imageFolder))
                Directory.CreateDirectory(_imageFolder);

            DatabaseHelper.InitializeDatabase(_dbPath);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            SetupListView();
            btnConnect_Click(null, null);
        }

        private void SetupListView()
        {
            listViewFoods.View = View.Details;
            listViewFoods.FullRowSelect = true;
            listViewFoods.GridLines = true;
            listViewFoods.Columns.Clear();
            listViewFoods.Columns.Add("Tên món", 150);
            listViewFoods.Columns.Add("Người đăng", 120);
            listViewFoods.Columns.Add("Quyền hạn", 100);
            listViewFoods.Columns.Add("Ảnh", 180);
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_tcpClient?.Connected == true)
                DisconnectFromServer();
            else
                ConnectToServer();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    lblSelectedImage.Text = $"✅ {Path.GetFileName(_selectedImagePath)}";
                    lblSelectedImage.ForeColor = Color.Green;

                    try
                    {
                        using (var fs = new FileStream(_selectedImagePath, FileMode.Open, FileAccess.Read))
                        using (var img = Image.FromStream(fs))
                        {
                            pictureBoxPreview.Image = new Bitmap(img);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("❌ Lỗi tải ảnh!", "Lỗi");
                    }
                }
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string ten = textBoxFoodName.Text.Trim();
            string nguoi = textBoxUserName.Text.Trim();
            string quyen = textBoxPermission.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(nguoi))
            {
                MessageBox.Show("❌ Vui lòng nhập tên món và tên người dùng!", "Thông báo");
                return;
            }

            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                MessageBox.Show("❌ Vui lòng chọn hình ảnh!", "Thông báo");
                return;
            }

            try
            {
                SaveToLocalDatabase(ten, nguoi, quyen, _selectedImagePath);

                if (_tcpClient?.Connected == true)
                    SendToServerAsync(ten, nguoi, quyen, _selectedImagePath);

                textBoxFoodName.Clear();
                textBoxUserName.Clear();
                textBoxPermission.Clear();
                _selectedImagePath = "";
                lblSelectedImage.Text = "Chưa chọn ảnh";
                lblSelectedImage.ForeColor = Color.Red;
                pictureBoxPreview.Image = null;

                MessageBox.Show("✅ Đã thêm món ăn!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void btnMyFoods_Click(object sender, EventArgs e)
        {
            try
            {
                _myFoods.Clear();
                _myFoods = DatabaseHelper.GetAllFoods(_dbPath);
                DisplayListView(_myFoods);
                MessageBox.Show($"✅ Đã tải {_myFoods.Count} món ăn!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi: {ex.Message}", "Lỗi");
            }
        }

        private void btnCommunityFoods_Click(object sender, EventArgs e)
        {
            if (_tcpClient?.Connected != true)
            {
                MessageBox.Show("❌ Chưa kết nối Server!", "Lỗi");
                return;
            }

            SendRequestAsync("GetFoods");
        }

        private void btnRandomMyFood_Click(object sender, EventArgs e)
        {
            if (_myFoods.Count == 0)
            {
                MessageBox.Show("❌ Danh sách trống!", "Thông báo");
                return;
            }

            Random rnd = new Random();
            var food = _myFoods[rnd.Next(_myFoods.Count)];
            ShowResult(food.ten, food.nguoi, food.hinh, isLocal: true);
            MessageBox.Show($"Hôm nay ăn: {food.ten}!", "Kết quả");
        }

        private void btnRandomCommunity_Click(object sender, EventArgs e)
        {
            if (_communityFoods.Count == 0)
            {
                MessageBox.Show("❌ Danh sách trống!", "Thông báo");
                return;
            }

            Random rnd = new Random();
            var food = _communityFoods[rnd.Next(_communityFoods.Count)];
            ShowResult(food.TenMonAn, food.NguoiDang, food.HinhAnh, isLocal: false);
            MessageBox.Show($"Hôm nay ăn: {food.TenMonAn}!\nCủa: {food.NguoiDang}", "Kết quả");
        }

        private void DisplayListView(List<(string ten, string nguoi, string quyen, string hinh)> foods)
        {
            listViewFoods.Items.Clear();

            foreach (var (ten, nguoi, quyen, hinh) in foods)
            {
                ListViewItem item = new ListViewItem(ten);
                item.SubItems.Add(nguoi);
                item.SubItems.Add(quyen);
                item.SubItems.Add(hinh);
                listViewFoods.Items.Add(item);
            }
        }

        private void SaveToLocalDatabase(string tenMon, string hoVaTen, string quyenHan, string imagePath)
        {
            string imageFileName = DateTime.Now.Ticks + "_" + Path.GetFileName(imagePath);
            string destPath = Path.Combine(_imageFolder, imageFileName);
            File.Copy(imagePath, destPath, true);

            int idNcc = DatabaseHelper.AddOrGetUser(_dbPath, hoVaTen, quyenHan);
            DatabaseHelper.AddFood(_dbPath, tenMon, imageFileName, idNcc);
        }

        private void ConnectToServer()
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(SERVER_IP, SERVER_PORT);
                _ns = _tcpClient.GetStream();
                _cts = new CancellationTokenSource();

                btnConnect.Text = "Ngắt kết nối";

                _ = Task.Run(() => ReceiveLoopAsync(_cts.Token));

                MessageBox.Show("✅ Kết nối Server thành công!", "Thông báo");
                SendRequestAsync("GetFoods");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi: {ex.Message}", "Lỗi");
                _tcpClient = null;
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                _cts?.Cancel();
                _ns?.Close();
                _tcpClient?.Close();
                _tcpClient = null;
                btnConnect.Text = "Kết nối";
                MessageBox.Show("✅ Đã ngắt kết nối!", "Thông báo");
            }
            catch { }
        }

        private async void SendRequestAsync(string action)
        {
            if (_tcpClient?.Connected != true) return;

            try
            {
                var payload = new { action };
                string json = JsonSerializer.Serialize(payload) + "\n";
                byte[] data = Encoding.UTF8.GetBytes(json);
                await _ns.WriteAsync(data, 0, data.Length);
            }
            catch { }
        }

        private async void SendToServerAsync(string ten, string nguoi, string quyen, string imgPath)
        {
            if (_tcpClient?.Connected != true) return;

            try
            {
                var payload = new
                {
                    action = "AddFood",
                    data = new { TenMonAn = ten, HinhAnh = imgPath, NguoiDang = nguoi, QuyenHan = quyen }
                };

                string json = JsonSerializer.Serialize(payload) + "\n";
                byte[] data = Encoding.UTF8.GetBytes(json);
                await _ns.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi gửi: {ex.Message}", "Lỗi");
            }
        }

        private async Task ReceiveLoopAsync(CancellationToken token)
        {
            try
            {
                using (StreamReader reader = new StreamReader(_ns, Encoding.UTF8))
                {
                    while (!token.IsCancellationRequested)
                    {
                        string line = await reader.ReadLineAsync();
                        if (line == null) break;
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        HandleServerMessage(line);
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch { }
        }

        private void HandleServerMessage(string json)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    if (!doc.RootElement.TryGetProperty("action", out var actionElem))
                        return;

                    string action = actionElem.GetString();

                    if (action == "UpdateFoods")
                    {
                        var foodsElem = doc.RootElement.GetProperty("foods");
                        _communityFoods.Clear();

                        foreach (var f in foodsElem.EnumerateArray())
                        {
                            _communityFoods.Add(new FoodItem
                            {
                                IDMA = f.GetProperty("IDMA").GetInt32(),
                                TenMonAn = f.GetProperty("TenMonAn").GetString() ?? "",
                                NguoiDang = f.GetProperty("NguoiDang").GetString() ?? "N/A",
                                QuyenHan = f.GetProperty("QuyenHan").GetString() ?? "N/A",
                                HinhAnh = f.GetProperty("HinhAnh").GetString() ?? ""
                            });
                        }

                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                listViewFoods.Items.Clear();
                                foreach (var f in _communityFoods)
                                {
                                    ListViewItem item = new ListViewItem(f.TenMonAn);
                                    item.SubItems.Add(f.NguoiDang);
                                    item.SubItems.Add(f.QuyenHan);
                                    item.SubItems.Add(f.HinhAnh);
                                    listViewFoods.Items.Add(item);
                                }
                            }));
                        }
                    }
                }
            }
            catch { }
        }

        private void ShowResult(string ten, string nguoi, string hinh, bool isLocal)
        {
            labelResult.Text = $"{ten} - {nguoi}";

            string path = hinh;

            if (isLocal)
            {
                if (!string.IsNullOrEmpty(hinh))
                {
                    var localPath = Path.Combine(_imageFolder, hinh);
                    if (File.Exists(localPath))
                        path = localPath;
                }
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        pictureBoxResult.Image = new Bitmap(img);
                    }
                }
                catch
                {
                    pictureBoxResult.Image = null;
                }
            }
            else
            {
                pictureBoxResult.Image = null;
            }
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
                {
                    conn.Open();
                    string sql = "DELETE FROM MonAn; DELETE FROM NguoiDung;";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                foreach (var file in Directory.GetFiles(_imageFolder))
                {
                    File.Delete(file);
                }

                _myFoods.Clear();
                listViewFoods.Items.Clear();
                pictureBoxResult.Image = null;
                labelResult.Text = "";

                MessageBox.Show("✅ Đã xóa toàn bộ dữ liệu local!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi xóa dữ liệu: {ex.Message}", "Lỗi");
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromServer();
            _cts?.Dispose();
        }

        private class FoodItem
        {
            public int IDMA { get; set; }
            public string TenMonAn { get; set; }
            public string NguoiDang { get; set; }
            public string QuyenHan { get; set; }
            public string HinhAnh { get; set; }
        }
    }
}
