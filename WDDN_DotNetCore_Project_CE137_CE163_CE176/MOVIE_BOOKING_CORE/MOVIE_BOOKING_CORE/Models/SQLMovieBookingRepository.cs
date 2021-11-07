using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public class SQLMovieBookingRepository :IMovieBookingRepository
    {
        private readonly AppDbContext context;

        public SQLMovieBookingRepository(AppDbContext context)
        {
            this.context = context;
        }
        MovieBooking IMovieBookingRepository.Add(MovieBooking MovieBooking)
        {
            context.MovieBookings.Add(MovieBooking);
            context.SaveChanges();
            return MovieBooking;
        }

        public MovieBooking Delete(int Id)
        {
            MovieBooking movieBooking = context.MovieBookings.Find(Id);
            if(movieBooking != null)
            {
                context.MovieBookings.Remove(movieBooking);
                context.SaveChanges();
            }
            return movieBooking;
        }

        IEnumerable<MovieBooking> IMovieBookingRepository.GetAllMovieBooking()
        {
            return context.MovieBookings;
        }

        public MovieBooking GetMovieBooking(int Id)
        {
            return (MovieBooking)context.MovieBookings.FirstOrDefault(m => m.Id == Id);
            //return context.MovieBookings.Find(Id);
        }

        public MovieBooking Update(MovieBooking MovieBookingChanges)
        {
            /*
                MovieBooking movieBooking = context.MovieBookings.Find(MovieBookingChanges.Id);
                if (movieBooking != null)
                {
                    movieBooking.name = MovieBookingChanges.name;
                    movieBooking.total = MovieBookingChanges.total;
                    movieBooking.showtime = MovieBookingChanges.showtime;
                    movieBooking.ticketType = MovieBookingChanges.ticketType;
                    movieBooking.date = movieBooking.date;

                    context.MovieBookings.Update(movieBooking);
                    context.SaveChanges();
                }
            */
            var movieBooking = context.MovieBookings.Attach(MovieBookingChanges);
            movieBooking.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return MovieBookingChanges;
        }
        IEnumerable<MovieTicket> IMovieBookingRepository.GetMovieTickets()
        {
            return context.MovieTickets;
        }

    }
}
