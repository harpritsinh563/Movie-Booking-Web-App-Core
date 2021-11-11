using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.ViewModels
{
    public class MovieTicketViewModel
    {
        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string MovieDescription { get; set; }

        public IFormFile MoviePoster { get; set; }

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
