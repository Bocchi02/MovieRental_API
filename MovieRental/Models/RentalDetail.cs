using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieRental.Models
{
    public class RentalDetail
    {
        public int RentalDetailID { get; set; }
        public int RentalID { get; set; }
        public int MovieID { get; set; }

        //navigation
        [JsonIgnore]
        public RentalHeader RentalHeader { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
    }
}
