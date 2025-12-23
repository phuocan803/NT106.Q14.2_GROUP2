using HtmlAgilityPack;
using MovieBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieBookingApp.Services
{
    public class WebScraper
    {
        public async Task<int> GetMovieCountAsync(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='col-lg-4 col-md-4 col-sm-8 col-xs-16 padding-right-30 padding-left-30 padding-bottom-30']");
            return nodes?.Count ?? 0;
        }

        public async Task<List<Movie>> GetMoviesAsync(Action<int> reportProgress)
        {
            var url = "https://betacinemas.vn/phim.htm";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var movies = new List<Movie>();
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='col-lg-4 col-md-4 col-sm-8 col-xs-16 padding-right-30 padding-left-30 padding-bottom-30']");
            int progress = 0;

            if (nodes == null)
                return movies;
            int processed = 0;
            foreach (var node in nodes)
            {
                var titleNode = node.SelectSingleNode(".//h3/a");
                var title = titleNode.InnerText.Trim();
                var detailUrl = titleNode.GetAttributeValue("href", "");
                var poster = node.SelectSingleNode(".//img").GetAttributeValue("src", "");
                var genreNode = node.SelectSingleNode(".//ul/li[1]");
                var durationNode = node.SelectSingleNode(".//ul/li[2]");

                string genre = genreNode?.InnerText.Replace("Thể loại:", "").Trim() ?? "Không rõ";
                string duration = durationNode?.InnerText.Replace("Thời lượng:", "").Trim() ?? "Không rõ";
                duration = Regex.Replace(duration, @"\s+", " ");

                movies.Add(new Movie
                {
                    TenPhim = title,
                    PosterUrl = poster,
                    ChiTietUrl = "https://betacinemas.vn" + detailUrl,
                    GiaVe = 45000,
                    TheLoai = genre,
                    ThoiLuong = duration
                });

                processed++;
                reportProgress(processed);
                await Task.Delay(50);

            }
            return movies;
        }
    }
}
