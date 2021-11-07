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
        public string ticketType { get; set; }
        [Required]
        public string showTime { get; set; }
        public DateTime showDate { get; set; }
        [Required]
        public int ticketNo {get; set;}
        public int ticketId { get; set; }

        [Required]
        public string name { get; set; }

    }
}
