using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MovieRental.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public decimal RentalPrice { get; set; }
        public ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
