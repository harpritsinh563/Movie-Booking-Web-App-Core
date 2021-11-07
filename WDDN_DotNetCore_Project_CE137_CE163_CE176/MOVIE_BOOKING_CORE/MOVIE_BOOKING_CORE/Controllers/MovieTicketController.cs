using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOVIE_BOOKING_CORE.Models;

namespace MOVIE_BOOKING_CORE.Controllers
{
    public class MovieTicketController : Controller
    {

        private readonly IMovieTicketRepository _movieticketrepo;

        public MovieTicketController(IMovieTicketRepository movieticketrepo)
        {
            _movieticketrepo = movieticketrepo;
        }


        public IActionResult Index()
        {
            var model = _movieticketrepo.GetAllMovieTickets();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieTicket movieTicket)
        {
            if(ModelState.IsValid)
            {
                MovieTicket new_movie_ticket = _movieticketrepo.Add(movieTicket);
                return RedirectToAction("details", new { id = new_movie_ticket.Id });
            }
            return View();
        }

        public ViewResult Details(int Id)
        {
            MovieTicket movie_ticket = _movieticketrepo.GetMovieTicket(Id);
            if(movie_ticket==null)
            {
                Response.StatusCode = 404;
                return View("Movie Not Found", Id);
            }
            return View(movie_ticket);
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            return RedirectToAction("Create", "MovieBooking",new {Id = id });
        }

        [HttpGet]

        public ViewResult Edit(int Id)
        {
            MovieTicket movieTicket = _movieticketrepo.GetMovieTicket(Id);
            return View(movieTicket);
        }

        [HttpPost]
        public IActionResult Edit(MovieTicket MovieTicketChanges)
        {
            if(ModelState.IsValid)
            {
                MovieTicket movieTicket = _movieticketrepo.GetMovieTicket(MovieTicketChanges.Id);
                movieTicket.MovieDescription = MovieTicketChanges.MovieDescription;
                movieTicket.MovieName = MovieTicketChanges.MovieName;
                movieTicket.MoviePoster = MovieTicketChanges.MoviePoster;
                movieTicket.SilverPrice = MovieTicketChanges.SilverPrice;
                movieTicket.GoldPrice = MovieTicketChanges.GoldPrice;
                movieTicket.PlatinumPrice = MovieTicketChanges.PlatinumPrice;
                movieTicket.startDate = MovieTicketChanges.startDate;
                
                MovieTicket updatedMovTicket = _movieticketrepo.Update(movieTicket);

                return RedirectToAction("index");
            }
            return View(MovieTicketChanges);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            MovieTicket movieTicket = _movieticketrepo.GetMovieTicket(Id);
            if(movieTicket==null)
            {
                return NotFound();
            }
            return View(movieTicket);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            MovieTicket movieticket = _movieticketrepo.GetMovieTicket(Id);
            _movieticketrepo.Delete(movieticket.Id);

            return RedirectToAction("index");
        }
    }
}
