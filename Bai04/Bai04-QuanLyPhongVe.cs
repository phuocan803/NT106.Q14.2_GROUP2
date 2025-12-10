using Bai04;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private List<Movie> movies = new List<Movie>();
        private Movie selectedMovie = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCrawl_Click(object sender, EventArgs e)
        {
            btnCrawl.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            try
            {
                await CrawlMovieData();
                MessageBox.Show($"Tải Phim thành công {movies.Count} phim!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                btnCrawl.Enabled = true;
                progressBar1.Visible = false;
            }
        }

        private async Task CrawlMovieData()
        {
            string url = "https://betacinemas.vn/phim.htm";
            movies.Clear();

            progressBar1.Value = 20;
            Application.DoEvents();

            string html = await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
                    return client.DownloadString(url);
                }
            });

            // Lưu debug
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(Path.Combine(desktopPath, "debug.html"), html);

            progressBar1.Value = 40;
            Application.DoEvents();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            progressBar1.Value = 60;
            Application.DoEvents();

            // SELECTOR ĐÚNG - Tìm các div chứa phim
            var movieDivs = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4') and contains(@class, 'col-md-4')]//div[@class='product-item no-padding']");

            if (movieDivs == null || movieDivs.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phim!");
                return;
            }

            HashSet<string> addedTitles = new HashSet<string>();

            foreach (var movieDiv in movieDivs)
            {
                try
                {
                    var movie = new Movie();

                    // Lấy ảnh từ pi-img-wrapper
                    var imgNode = movieDiv.SelectSingleNode(".//div[@class='pi-img-wrapper']//img[@class='img-responsive border-radius-20']");
                    if (imgNode != null)
                    {
                        movie.ImageUrl = imgNode.GetAttributeValue("src", "");
                    }

                    // Bỏ qua nếu không có ảnh hoặc ảnh là icon
                    if (string.IsNullOrEmpty(movie.ImageUrl) ||
                        movie.ImageUrl.Contains("/icons/") ||
                        movie.ImageUrl.Contains("logo"))
                    {
                        continue;
                    }

                    // Lấy thông tin phim từ phần film-info (nằm bên ngoài movieDiv)
                    // Phải tìm từ parent node
                    var parentRow = movieDiv.SelectSingleNode("ancestor::div[@class='row'][1]");
                    if (parentRow != null)
                    {
                        // Tìm film-info trong cùng row
                        var filmInfo = parentRow.SelectSingleNode(".//div[contains(@class, 'film-info')]");
                        if (filmInfo != null)
                        {
                            // Lấy title
                            var titleNode = filmInfo.SelectSingleNode(".//h3/a");
                            if (titleNode != null)
                            {
                                movie.Title = System.Web.HttpUtility.HtmlDecode(titleNode.InnerText.Trim());
                                movie.DetailUrl = titleNode.GetAttributeValue("href", "");

                                // Xử lý URL
                                if (!string.IsNullOrEmpty(movie.DetailUrl) && movie.DetailUrl.StartsWith("/"))
                                {
                                    movie.DetailUrl = "https://betacinemas.vn" + movie.DetailUrl;
                                }
                            }

                            // Lấy thể loại
                            var genreNode = filmInfo.SelectSingleNode(".//li[contains(., 'Thể loại:')]");
                            if (genreNode != null)
                            {
                                string genreText = System.Web.HttpUtility.HtmlDecode(genreNode.InnerText);
                                movie.Genre = genreText.Replace("Thể loại:", "").Trim();
                            }

                            // Lấy thời lượng
                            var durationNode = filmInfo.SelectSingleNode(".//li[contains(., 'Thời lượng:')]");
                            if (durationNode != null)
                            {
                                string durationText = System.Web.HttpUtility.HtmlDecode(durationNode.InnerText);
                                movie.Duration = durationText.Replace("Thời lượng:", "").Trim();
                            }
                        }
                    }

                    // Kiểm tra và thêm vào danh sách
                    if (!string.IsNullOrEmpty(movie.Title) &&
                        !string.IsNullOrEmpty(movie.ImageUrl) &&
                        !addedTitles.Contains(movie.Title))
                    {
                        movies.Add(movie);
                        addedTitles.Add(movie.Title);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi parse: {ex.Message}");
                    continue;
                }
            }

            progressBar1.Value = 90;

            if (movies.Count > 0)
            {
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
                File.WriteAllText(Path.Combine(desktopPath, "movies.json"), json);
            }

            progressBar1.Value = 100;
            DisplayMovies();
        }

        private void DisplayMovies()
        {
            flowLayoutPanel1.Controls.Clear();

            if (movies.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "⚠ Không có phim để hiển thị\nVui lòng thử Tải Phim lại!",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Red,
                    Padding = new Padding(20)
                };
                flowLayoutPanel1.Controls.Add(lblEmpty);
                return;
            }

            foreach (var movie in movies)
            {
                Panel panel = new Panel
                {
                    Width = 200,
                    Height = 320,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = movie,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                PictureBox pb = new PictureBox
                {
                    Width = 190,
                    Height = 250,
                    Left = 5,
                    Top = 5,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightGray
                };

                try { pb.LoadAsync(movie.ImageUrl); } catch { }

                Label lbl = new Label
                {
                    Text = movie.Title,
                    AutoSize = false,
                    Width = 190,
                    Height = 60,
                    Left = 5,
                    Top = 260,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };

                panel.MouseEnter += (s, e) =>
                {
                    panel.BackColor = Color.LightBlue;
                    panel.BorderStyle = BorderStyle.Fixed3D;
                };
                panel.MouseLeave += (s, e) =>
                {
                    panel.BackColor = Color.White;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                };

                EventHandler click = (s, e) => MoviePanel_Click(movie);
                panel.Click += click;
                pb.Click += click;
                lbl.Click += click;

                panel.Controls.Add(pb);
                panel.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(panel);
            }

            lblSelectedMovie.Text = $"Đã load {movies.Count} phim";
        }

        private void MoviePanel_Click(Movie movie)
        {
            selectedMovie = movie;
            lblSelectedMovie.Text = $"Đã chọn: {movie.Title}";
            lblSelectedMovie.ForeColor = Color.Blue; // Đổi màu Blue

            // Hiển thị thông tin chi tiết
            string info = $"🎬 {movie.Title}\n\n";
            if (!string.IsNullOrEmpty(movie.Genre))
                info += $"Thể loại: {movie.Genre}\n";
            if (!string.IsNullOrEmpty(movie.Duration))
                info += $"Thời lượng: {movie.Duration}\n";
            if (!string.IsNullOrEmpty(movie.Description))
                info += $"\n{movie.Description}\n";
            info += $"\nGiá vé: {movie.Price:N0} VNĐ\n\n";
            info += "Bạn có muốn mở trang chi tiết không?";

            var result = MessageBox.Show(info, "Thông tin phim", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes && !string.IsNullOrEmpty(movie.DetailUrl))
            {
                try
                {
                    System.Diagnostics.Process.Start(movie.DetailUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở link: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("movies.json"))
                {
                    string json = File.ReadAllText("movies.json");
                    movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    if (movies != null && movies.Count > 0)
                    {
                        DisplayMovies();
                        MessageBox.Show($"Đã load {movies.Count} phim từ file lưu trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể load movies.json: {ex.Message}");
            }
        }
        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn phim chưa
            if (selectedMovie == null)
            {
                MessageBox.Show("⚠ Vui lòng chọn phim trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tên khách hàng
            string name = txtCustomerName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("⚠ Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            // Tính toán
            int qty = (int)numQuantity.Value;
            decimal total = selectedMovie.Price * qty;

            // Xác nhận đặt vé
            string confirmMsg = $"Xác nhận đặt vé?\n\n" +
                              $"Khách hàng: {name}\n" +
                              $"Phim: {selectedMovie.Title}\n" +
                              $"Số vé: {qty}\n" +
                              $"Đơn giá: {selectedMovie.Price:N0} VNĐ\n" +
                              $"Tổng tiền: {total:N0} VNĐ";

            var confirm = MessageBox.Show(confirmMsg, "Xác nhận đặt vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Lưu thông tin đặt vé
                    string bookingInfo = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] " +
                                       $"Khách: {name} | " +
                                       $"Phim: {selectedMovie.Title} | " +
                                       $"Số vé: {qty} | " +
                                       $"Tổng: {total:N0} VNĐ\n";

                    File.AppendAllText("bookings.txt", bookingInfo);

                    // Thông báo thành công
                    string successMsg = $"✓ Đặt vé thành công!\n\n" +
                                      $"Khách hàng: {name}\n" +
                                      $"Phim: {selectedMovie.Title}\n" +
                                      $"Số vé: {qty}\n" +
                                      $"Tổng tiền: {total:N0} VNĐ\n\n" +
                                      $"Thông tin đã được lưu vào bookings.txt";

                    MessageBox.Show(successMsg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    txtCustomerName.Clear();
                    numQuantity.Value = 1;
                    selectedMovie = null;
                    lblSelectedMovie.Text = "Chưa chọn phim";
                    lblSelectedMovie.ForeColor = Color.Gray;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}