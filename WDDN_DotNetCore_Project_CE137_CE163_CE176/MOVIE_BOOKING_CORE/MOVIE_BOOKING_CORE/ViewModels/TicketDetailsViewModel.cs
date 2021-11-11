using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MOVIE_BOOKING_CORE.ViewModels
{
    public class TicketDetailsViewModel
    {
        [Required]
        [Display(Name ="Ticket Type")]
        public string ticketType { get; set; }
        [Required]
        [Display(Name = "Show Time")]
        public string showTime { get; set; }
        
        [Display(Name = "Show Date")]
        public string showDate { get; set; }

        [Display(Name = "# of Tickets")]
        [Required]
        public int ticketNo {get; set;}

        [Display(Name ="Silver Price")]
        public int silver_price { get; set; }

        [Display(Name = "Gold Price")]
        public int gold_price { get; set; }

        [Display(Name = "Platinum Price")]
        public int platinum_price { get; set; }

        public string name { get; set; }

    }
}
