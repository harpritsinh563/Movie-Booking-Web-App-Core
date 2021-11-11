using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<MovieBooking>Bookings { get; set; }
    }
}
