namespace MovieBookingApp.Models
{
    public class Ticket
    {
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * Movie.GiaVe;
    }
}
