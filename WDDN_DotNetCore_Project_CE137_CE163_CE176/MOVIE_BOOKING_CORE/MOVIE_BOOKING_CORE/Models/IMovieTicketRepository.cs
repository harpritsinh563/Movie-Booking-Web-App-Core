using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public interface IMovieTicketRepository
    {
        MovieTicket GetMovieTicket(int Id);
        IEnumerable<MovieTicket> GetAllMovieTickets();
        MovieTicket Add(MovieTicket MovieTicket);
        MovieTicket Update(MovieTicket MovieTicketChanges);
        MovieTicket Delete(int Id);

    }
}
