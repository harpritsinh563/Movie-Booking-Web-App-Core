using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace MOVIE_BOOKING_CORE.Models
{
    public class MovieTicket
    {
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string MovieDescription { get; set; }

        public string MoviePoster { get; set; }

        [Required]
        public int SilverPrice { get; set; }

        [Required] 
        public int GoldPrice { get; set; }

        [Required]
        public int PlatinumPrice { get; set; }

        [Required]
        public DateTime startDate { get; set; }

    }

}
