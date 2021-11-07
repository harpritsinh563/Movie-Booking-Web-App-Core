using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public interface IMovieBookingRepository
    {
        MovieBooking GetMovieBooking(int Id);
        IEnumerable<MovieBooking> GetAllMovieBooking();
        MovieBooking Add(MovieBooking MovieBooking);
        MovieBooking Update(MovieBooking MovieBookingChanges);
        MovieBooking Delete(int Id);

        IEnumerable<MovieTicket> GetMovieTickets();
    }
}
