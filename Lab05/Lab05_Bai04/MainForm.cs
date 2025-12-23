using MovieBookingApp.Models;
using MovieBookingApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Lab05_Bai04
{
    public partial class MainForm : Form
    {
        private List<Movie> Movies = new List<Movie>();

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Point location, Size size)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = location;
            this.Size = size;
        }

        private async void btnLoadMovies_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = 0;

            var scraper = new WebScraper();

            int totalMovies = await scraper.GetMovieCountAsync("https://betacinemas.vn/phim.htm");

            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = totalMovies;

            Movies = await scraper.GetMoviesAsync(progress => ProgressBar.Value = progress);

            flowLayoutPanelMovies.Controls.Clear();

            JsonService.SaveMovies(Movies);

            foreach (var movie in Movies)
            {
                var card = RenderMovieCard(movie);
                flowLayoutPanelMovies.Controls.Add(card);
            }

            ProgressBar.Value = ProgressBar.Maximum;
        }

        /// <summary>
        /// Tạo giao diện một card phim đẹp – chuẩn poster 150x225
        /// </summary>
        private Panel RenderMovieCard(Movie movie)
        {
            // Card
            Panel card = new Panel
            {
                Width = 880,
                Height = 240,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Cursor = Cursors.Hand
            };

            // Poster
            PictureBox poster = new PictureBox
            {
                Width = 150,
                Height = 225,
                Location = new Point(10, 8),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            try
            {
                WebClient wc = new WebClient();
                byte[] data = wc.DownloadData(movie.PosterUrl);
                poster.Image = Image.FromStream(new System.IO.MemoryStream(data));
            }
            catch
            {
                poster.BackColor = Color.Gray;
            }

            // Tilte
            Label titleLabel = new Label
            {
                Text = movie.TenPhim,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(180, 20),
                AutoSize = true
            };

            // Lable link
            LinkLabel linkLabel = new LinkLabel
            {
                Text = movie.ChiTietUrl,
                Location = new Point(180, 60),
                AutoSize = true
            };

            linkLabel.LinkClicked += (s, e) =>
            {
                string cleanLink = movie.ChiTietUrl.Split('#')[0];
                System.Diagnostics.Process.Start(cleanLink);
            };

            // event 
            card.Click += (s, e) =>
            {
                var detailForm = new FormInformation(movie);
                detailForm.ShowDialog();
            };

            // add controls
            card.Controls.Add(poster);
            card.Controls.Add(titleLabel);
            card.Controls.Add(linkLabel);

            return card;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
