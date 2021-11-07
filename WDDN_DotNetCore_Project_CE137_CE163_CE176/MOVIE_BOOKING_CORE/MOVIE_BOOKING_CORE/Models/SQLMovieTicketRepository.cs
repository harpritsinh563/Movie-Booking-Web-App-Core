using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public class SQLMovieTicketRepository : IMovieTicketRepository
    {
        private readonly AppDbContext context;

        public SQLMovieTicketRepository(AppDbContext context)
        {
            this.context = context;
        }

        MovieTicket IMovieTicketRepository.Add(MovieTicket MovieTicket)
        {
            context.Add(MovieTicket);
            context.SaveChanges();
            return MovieTicket;
        }

        MovieTicket IMovieTicketRepository.Delete(int Id)
        {
            MovieTicket movieTicket = context.MovieTickets.Find(Id);
            if(movieTicket!=null)
            {
                context.MovieTickets.Remove(movieTicket);
                context.SaveChanges();
            }
            return movieTicket;
        }

        IEnumerable<MovieTicket>IMovieTicketRepository.GetAllMovieTickets()
        {
            return context.MovieTickets;
        }

        MovieTicket IMovieTicketRepository.GetMovieTicket(int Id)
        {
            return context.MovieTickets.Find(Id);
        }

        MovieTicket IMovieTicketRepository.Update(MovieTicket MovieTicketChanges)
        {
            MovieTicket movieTicket = context.MovieTickets.Find(MovieTicketChanges.Id);
            if(movieTicket!=null)
            {
                movieTicket.MovieDescription = MovieTicketChanges.MovieDescription;
                movieTicket.MovieName = MovieTicketChanges.MovieName;
                movieTicket.MoviePoster = MovieTicketChanges.MoviePoster;
                movieTicket.SilverPrice = MovieTicketChanges.SilverPrice;
                movieTicket.GoldPrice = MovieTicketChanges.GoldPrice;
                movieTicket.PlatinumPrice = MovieTicketChanges.PlatinumPrice;
                movieTicket.startDate = MovieTicketChanges.startDate;
                context.MovieTickets.Update(movieTicket);
                context.SaveChanges();
            }
            return movieTicket;
        }

    }
}
