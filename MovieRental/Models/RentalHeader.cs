using Microsoft.AspNetCore.Localization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieRental.Models
{
    public class RentalHeader
    {
        public int RentalID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }


        //Navigation
        [JsonIgnore]
        public Customer?  Customer { get; set; }
        [JsonIgnore]
        public ICollection<RentalDetail>? RentalDetails { get; set; }
    }
}
