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
        [Display(Name ="Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string MovieDescription { get; set; }

        public string MoviePoster { get; set; }

        [Required]
        [Display(Name = "Silver Price")]
        public int SilverPrice { get; set; }

        [Required]
        [Display(Name = "Gold Price")]
        public int GoldPrice { get; set; }

        [Required]
        [Display(Name = "Platinum Price")]
        public int PlatinumPrice { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

    }

}
