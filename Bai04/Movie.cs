namespace Bai04
{
    public class Movie
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string DetailUrl { get; set; }
        public string Description { get; set; }

        // THÊM CÁC DÒNG NÀY
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string ReleaseDate { get; set; }
        public decimal Price { get; set; } = 80000; // Giá mặc định
    }
}