using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai05.Shared;

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

        private string _serverIP = "10.45.196.100";
        private int _serverPort = 5000;

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

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_tcpClient?.Connected == true)
            {
                DisconnectFromServer();
            }
            else
            {
                // ✅ HIỂN THỊ DIALOG NHẬP IP
                using (var form = new Form())
                {
                    form.Text = "Kết nối Server";
                    form.Size = new Size(400, 180);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    Label lblIP = new Label() { Left = 20, Top = 20, Text = "IP Server:", Width = 80 };
                    TextBox txtIP = new TextBox() { Left = 110, Top = 20, Width = 250, Text = _serverIP };

                    Label lblPort = new Label() { Left = 20, Top = 60, Text = "Port:", Width = 80 };
                    TextBox txtPort = new TextBox() { Left = 110, Top = 60, Width = 250, Text = _serverPort.ToString() };

                    Button btnOK = new Button() { Text = "Kết nối", Left = 150, Width = 100, Top = 100, DialogResult = DialogResult.OK };
                    Button btnCancel = new Button() { Text = "Hủy", Left = 260, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

                    form.Controls.Add(lblIP);
                    form.Controls.Add(txtIP);
                    form.Controls.Add(lblPort);
                    form.Controls.Add(txtPort);
                    form.Controls.Add(btnOK);
                    form.Controls.Add(btnCancel);

                    form.AcceptButton = btnOK;
                    form.CancelButton = btnCancel;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _serverIP = txtIP.Text.Trim();
                        if (int.TryParse(txtPort.Text.Trim(), out int port))
                        {
                            _serverPort = port;
                        }
                        ConnectToServer();
                    }
                }
            }
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
                        using (var fs = new FileStream(_selectedImagePath, FileMode.Open))
                        {
                            pictureBoxPreview.Image = new Bitmap(Image.FromStream(fs));
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
            ShowResult(food.ten, food.nguoi, food.hinh);
            MessageBox.Show($"🎉 Hôm nay ăn: {food.ten}!", "Kết quả");
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
            ShowResult(food.TenMonAn, food.NguoiDang, food.HinhAnh);
            MessageBox.Show($"🎉 Hôm nay ăn: {food.TenMonAn}!\n👤 Của: {food.NguoiDang}", "Kết quả");
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
                _tcpClient.Connect(_serverIP, _serverPort);  // ✅ Dùng biến thay vì const
                _ns = _tcpClient.GetStream();
                _cts = new CancellationTokenSource();

                btnConnect.Text = "🔴 Ngắt kết nối";

                _ = Task.Run(() => ReceiveLoopAsync(_cts.Token));

                MessageBox.Show($"✅ Đã kết nối {_serverIP}:{_serverPort}!", "Thành công");
                SendRequestAsync("GetFoods");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Không thể kết nối!\n{ex.Message}", "Lỗi");
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
                btnConnect.Text = "🟢 Kết Nối";
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

        private void ShowResult(string ten, string nguoi, string hinh)
        {
            labelResult.Text = $"🎉 {ten} - {nguoi}";

            if (!string.IsNullOrEmpty(hinh) && File.Exists(hinh))
            {
                try
                {
                    using (var fs = new FileStream(hinh, FileMode.Open))
                    {
                        pictureBoxResult.Image = new Bitmap(Image.FromStream(fs));
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