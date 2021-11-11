using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOVIE_BOOKING_CORE.Models;
using Microsoft.AspNetCore.Authorization;
using MOVIE_BOOKING_CORE.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MOVIE_BOOKING_CORE.Controllers
{
    public class MovieTicketController : Controller
    {

        private readonly IMovieTicketRepository _movieticketrepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public MovieTicketController(IMovieTicketRepository movieticketrepo,IHostingEnvironment hostingEnvironment)
        {
            _movieticketrepo = movieticketrepo;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = _movieticketrepo.GetAllMovieTickets();
            return View(model);
        }

        [Authorize(Roles="Admin")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(MovieTicketViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFilename = null;
                if(model.MoviePoster!=null)
                {
                   string uploadFolder= Path.Combine(hostingEnvironment.WebRootPath,"images");
                    uniqueFilename=Guid.NewGuid() + "_" + model.MoviePoster.FileName;
                    string filepath = Path.Combine(uploadFolder, uniqueFilename);
                    model.MoviePoster.CopyTo(new FileStream(filepath, FileMode.Create));                        
                }

                MovieTicket new_movie_ticket = new MovieTicket
                {
                    MovieName = model.MovieName,
                    MovieDescription = model.MovieDescription,
                    SilverPrice = model.SilverPrice,
                    GoldPrice=model.GoldPrice,
                    PlatinumPrice=model.PlatinumPrice,
                    startDate=model.startDate,
                    MoviePoster=uniqueFilename
                };
                _movieticketrepo.Add(new_movie_ticket);
                //MovieTicket new_movie_ticket = _movieticketrepo.Add(movieTicket);
                return RedirectToAction("details", new { id = new_movie_ticket.Id });
            }
            return View();
        }
        [Authorize]

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
        [Authorize]

        [HttpGet]
        public IActionResult Book(int id)
        {
            return RedirectToAction("Create", "MovieBooking",new {Id = id });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            MovieTicket movieTicket = _movieticketrepo.GetMovieTicket(Id);
            return View(movieTicket);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            MovieTicket movieticket = _movieticketrepo.GetMovieTicket(Id);
            _movieticketrepo.Delete(movieticket.Id);

            return RedirectToAction("index");
        }
    }
}
