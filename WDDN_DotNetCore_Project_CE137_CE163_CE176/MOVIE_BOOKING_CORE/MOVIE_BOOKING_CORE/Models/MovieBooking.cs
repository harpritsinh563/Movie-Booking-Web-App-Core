using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MOVIE_BOOKING_CORE.Models;
namespace MOVIE_BOOKING_CORE.Models
{
    public class MovieBooking
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int total { get; set; }

        [Required]
        public string showtime { get; set; }

        [Required]
        public string ticketType { get; set; }

        [Required]
        public DateTime date { get; set; }
        //public int TicketId { get; set; }
        //public MovieTicket Ticket { get; set; }
        /*
         * userid form viewModels
         */
    }
}
