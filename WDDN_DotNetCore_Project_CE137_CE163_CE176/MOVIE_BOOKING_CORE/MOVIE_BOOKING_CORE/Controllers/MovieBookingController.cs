using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MOVIE_BOOKING_CORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MOVIE_BOOKING_CORE.ViewModels;
using System;

namespace MOVIE_BOOKING_CORE.Controllers
{

    public class MovieBookingController : Controller
    {
        private readonly IMovieBookingRepository _movieBookingRepo;
        private readonly IMovieTicketRepository _movieTicketRepo;

        public static List<string> ticketType = new List<string>
        {
            "Silver",
            "Gold",
            "Platinum"
        };
        public static List<string> showTime = new List<string> 
        { 
            "10:00", 
            "12:00", 
            "14:00", 
            "16:00", 
            "18:00" 
        };



        public MovieBookingController(IMovieBookingRepository movieBookingRepo, IMovieTicketRepository movieticketrepo)
        {
            _movieBookingRepo = movieBookingRepo;
            _movieTicketRepo = movieticketrepo;
        }
        public IActionResult Index()
        {
            var model = _movieBookingRepo.GetAllMovieBooking();
            return View(model);
        }

        public ViewResult Details(int Id)
        {
            MovieBooking moviebooking = _movieBookingRepo.GetMovieBooking(Id);
            if (moviebooking == null)
            {
                Response.StatusCode = 404;
                return View("movienotfound", Id);
            }
            return View(moviebooking);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {
            
            MovieTicket Movie = _movieTicketRepo.GetMovieTicket(Id);
            TicketDetailsViewModel newMovie = new TicketDetailsViewModel();
            newMovie.name = Movie.MovieName;
            DateTime cDate = Movie.startDate;
            String currDate = cDate.ToString("MM/dd/yyyy");

            List<string> showdates = new List<string>();
            showdates.Add(currDate);
            for(int i = 1; i < 7; i++)
            {
                cDate=cDate.AddDays(1.0);
                showdates.Add(cDate.ToString("MM/dd/yyyy"));
            }
            ViewData["showDatesList"] = new SelectList(showdates);
            ViewData["TicketId"] = Id;
            ViewData["ticketTypeList"] = new SelectList(ticketType);
            ViewData["showTimeList"] = new SelectList(showTime);
            Console.WriteLine(newMovie.name+"<br>");
            //viewdata["time"] = showtime;
            //viewdata["tickettype"] = tickettype;
            return View(newMovie);
        }
        

        [HttpPost]
        public IActionResult Create(TicketDetailsViewModel movieBooking)
        {
            Console.WriteLine("outside");
            Console.WriteLine(movieBooking.name);
            Console.WriteLine(movieBooking.showTime);
            Console.WriteLine(movieBooking.ticketType);
            Console.WriteLine(movieBooking.showDate);
            Console.WriteLine(movieBooking.ticketNo);


            if (ModelState.IsValid)
            {
                Console.WriteLine("Indise");
                MovieBooking newmovieBooking = new MovieBooking();
                newmovieBooking.name = movieBooking.name;
                newmovieBooking.showtime = movieBooking.showTime;
                newmovieBooking.date = movieBooking.showDate;
                newmovieBooking.ticketType = movieBooking.ticketType;
                if(movieBooking.ticketType == "Silver")
                {
                    newmovieBooking.total = movieBooking.ticketNo * 110;
                }else if(movieBooking.ticketType == "Gold")
                {
                    newmovieBooking.total = movieBooking.ticketNo * 120;
                }
                else
                {
                    newmovieBooking.total = movieBooking.ticketNo * 150;

                }
                Console.WriteLine(newmovieBooking.name);
                Console.WriteLine(newmovieBooking.total);
                Console.WriteLine(newmovieBooking.showtime);
                Console.WriteLine(newmovieBooking.ticketType);
                Console.WriteLine(newmovieBooking.date);

                _movieBookingRepo.Add(newmovieBooking);

                Console.WriteLine(newmovieBooking.Id);
                Console.WriteLine(newmovieBooking);
                return RedirectToAction("details", new { Id = newmovieBooking.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieBooking movieBooking = _movieBookingRepo.GetMovieBooking(id);
            //ViewData["TicketId"] = new SelectList(_movieBookingRepo.GetMovieTickets(), "Id", "name", movieBooking.TicketId);

            return View(movieBooking);
        }

        [HttpPost]
        public IActionResult Edit(MovieBooking model)
        {
            if (ModelState.IsValid)
            {
                MovieBooking movieBooking = _movieBookingRepo.GetMovieBooking(model.Id);
                movieBooking.name = model.name;
                movieBooking.showtime = model.showtime;
                movieBooking.ticketType = model.ticketType;
                movieBooking.total = model.total;
                movieBooking.date = model.date;
                MovieBooking updatedMovieBooking = _movieBookingRepo.Update(movieBooking);

                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            MovieBooking movieBooking = _movieBookingRepo.GetMovieBooking(id);
            if(movieBooking == null)
            {
                return NotFound();
            }
            return View(movieBooking);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movieBooking = _movieBookingRepo.GetMovieBooking(id);
            _movieBookingRepo.Delete(movieBooking.Id);

            return RedirectToAction("index");
        }

    }
}
