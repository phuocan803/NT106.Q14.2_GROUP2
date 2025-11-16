using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab03_Bai04
{
    public partial class Client : Form
    {
        TcpClient client;
        NetworkStream ns;
        Thread listenThread;

        // Lưu trạng thái ghế hiện tại từ Server
        Dictionary<string, Dictionary<int, List<string>>> bookedSeats = new Dictionary<string, Dictionary<int, List<string>>>();

        public Client()
        {
            InitializeComponent();
            this.Load += Bai04_Load;
        }
        private void Bai04_Load(object sender, EventArgs e)
        {
            comboBox_Room.Enabled = false;
            checkedListBox_Seat.Enabled = false;
            textBox_FullName.Enabled = false;
            comboBox_MovieName.Enabled = false;
        }

        void ConnectToServer()
        {
            try
            {
                string ip = textBox_IP_Remote_Host.Text.Trim();
                int port = int.Parse(textBox_Port.Text.Trim());

                client = new TcpClient(ip, port);
                ns = client.GetStream();

                listenThread = new Thread(ListenServer);
                listenThread.IsBackground = true;
                listenThread.Start();

                MessageBox.Show($"Đã kết nối đến Server {ip}:{port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới server: " + ex.Message);
            }
        }

        void ListenServer()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytes = ns.Read(buffer, 0, buffer.Length);
                    if (bytes <= 0) continue;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    ProcessServerMessage(msg);
                }
            }
            catch { }
        }

        void ProcessServerMessage(string msg)
        {
            string[] parts = msg.Split('|');

            this.Invoke((MethodInvoker)(() =>
            {
                if (parts[0] == "UPDATE")
                {
                    string movie = parts[1];
                    int room = int.Parse(parts[2]);
                    string[] seats = parts[3].Split(',');

                    // Cập nhật trạng thái ghế
                    if (!bookedSeats.ContainsKey(movie))
                        bookedSeats[movie] = new Dictionary<int, List<string>>();

                    bookedSeats[movie][room] = new List<string>(seats);

                    // Nếu Client đang xem đúng phim & phòng, cập nhật CheckedListBox
                    if (comboBox_MovieName.SelectedItem?.ToString() == movie &&
                        comboBox_Room.SelectedItem?.ToString() == room.ToString())
                    {
                        UpdateCheckedListBox();
                    }
                }
                else if (parts[0] == "SEATS")
                {
                    string movie = comboBox_MovieName.SelectedItem?.ToString();
                    int room = int.Parse(comboBox_Room.SelectedItem?.ToString() ?? "0");
                    string[] seats = parts[1].Split(',');

                    if (!bookedSeats.ContainsKey(movie))
                        bookedSeats[movie] = new Dictionary<int, List<string>>();
                    bookedSeats[movie][room] = new List<string>(seats);

                    UpdateCheckedListBox();
                }
                else if (parts[0] == "BOOK_SUCCESS")
                {
                    MessageBox.Show("Đặt ghế thành công: " + parts[1]);
                    SendMessage($"GET_SEATS|{comboBox_MovieName.SelectedItem}|{comboBox_Room.SelectedItem}");
                }
                else if (parts[0] == "BOOK_FAIL")
                {
                    MessageBox.Show("Một số ghế đã được đặt: " + parts[1]);
                    SendMessage($"GET_SEATS|{comboBox_MovieName.SelectedItem}|{comboBox_Room.SelectedItem}");
                }
            }));
        }

        void SendMessage(string msg)
        {
            if (client == null || !client.Connected)
            {
                ConnectToServer();
                if (client == null || !client.Connected) return;
            }

            byte[] data = Encoding.UTF8.GetBytes(msg);
            ns.Write(data, 0, data.Length);
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
            textBox_FullName.Enabled = true;
            comboBox_MovieName.Enabled = true;
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            comboBox_Room.Enabled = false;
            checkedListBox_Seat.Enabled = false;
            textBox_FullName.Enabled = false;
            comboBox_MovieName.Enabled = false;
            MessageBox.Show("Đã ngắt kết nối với Server!");
        }

        private void comboBox_MovieName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Room.Enabled = true;   
            comboBox_Room.Items.Clear();

            string movie = comboBox_MovieName.SelectedItem.ToString();

            if (movie == "Đào, phở và piano")
                comboBox_Room.Items.AddRange(new object[] { 1, 2, 3 });
            else if (movie == "Mai")
                comboBox_Room.Items.AddRange(new object[] { 2, 3 });
            else if (movie == "Gặp lại chị bầu")
                comboBox_Room.Items.Add(1);
            else if (movie == "Tarot")
                comboBox_Room.Items.Add(3);
        }


        private void comboBox_Room_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_Seat.Enabled = true;

            // Lấy trạng thái ghế từ Server
            SendMessage($"GET_SEATS|{comboBox_MovieName.SelectedItem}|{comboBox_Room.SelectedItem}");
        }

        void UpdateCheckedListBox()
        {
            string movie = comboBox_MovieName.SelectedItem.ToString();
            int room = int.Parse(comboBox_Room.SelectedItem.ToString());

            string[] allSeats = { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5" };

            checkedListBox_Seat.Items.Clear();
            foreach (var seat in allSeats)
                checkedListBox_Seat.Items.Add(seat);

            // Đánh dấu các ghế đã bị đặt
            if (bookedSeats.ContainsKey(movie) && bookedSeats[movie].ContainsKey(room))
            {
                foreach (int i in Enumerable.Range(0, checkedListBox_Seat.Items.Count))
                {
                    string seat = checkedListBox_Seat.Items[i].ToString();
                    if (bookedSeats[movie][room].Contains(seat))
                        checkedListBox_Seat.SetItemCheckState(i, CheckState.Indeterminate);
                }
            }
        }

        private void button_Buy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_FullName.Text) ||
                comboBox_MovieName.SelectedItem == null ||
                comboBox_Room.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            List<string> seatsToBook = new List<string>();
            for (int i = 0; i < checkedListBox_Seat.Items.Count; i++)
                if (checkedListBox_Seat.GetItemCheckState(i) == CheckState.Checked)
                    seatsToBook.Add(checkedListBox_Seat.Items[i].ToString());

            if (seatsToBook.Count == 0)
            {
                MessageBox.Show("Chưa chọn ghế!");
                return;
            }

            string customerName = textBox_FullName.Text.Trim();
            string movie = comboBox_MovieName.SelectedItem.ToString();
            string room = comboBox_Room.SelectedItem.ToString();

            SendMessage($"BOOK_SEATS|{customerName}|{movie}|{room}|{string.Join(",", seatsToBook)}");
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            try { client?.Close(); } catch { }
            try { listenThread?.Interrupt(); } catch { }
            Close();
        }
    }
}
