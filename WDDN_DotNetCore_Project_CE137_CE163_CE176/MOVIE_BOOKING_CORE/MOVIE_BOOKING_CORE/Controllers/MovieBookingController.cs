using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MOVIE_BOOKING_CORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MOVIE_BOOKING_CORE.ViewModels;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MOVIE_BOOKING_CORE.Controllers
{
    [Authorize(Roles="User")]
    public class MovieBookingController : Controller
    {
        private readonly IMovieBookingRepository _movieBookingRepo;
        private readonly IMovieTicketRepository _movieTicketRepo;
        private readonly UserManager<AppUser> _userManager;
       
        public static List<string> ticketType = new List<string>
        {
            "Silver",
            "Gold",
            "Platinum"
        };
        public static List<string> showTime = new List<string> 
        { 
            "9AM-12PM",
            "12PM-3PM",
            "3PM-6PM", 
            "6PM-9PM", 
            "9PM-12AM" 
        };



        public MovieBookingController(IMovieBookingRepository movieBookingRepo, IMovieTicketRepository movieticketrepo, UserManager<AppUser> userManager)
        {
            _movieBookingRepo = movieBookingRepo;
            _movieTicketRepo = movieticketrepo;
            _userManager = userManager;

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
            string userid = _userManager.GetUserId(HttpContext.User);
            MovieTicket Movie = _movieTicketRepo.GetMovieTicket(Id);
            TicketDetailsViewModel newMovie = new TicketDetailsViewModel();
            newMovie.name = Movie.MovieName;
            DateTime cDate = Movie.startDate;
            newMovie.silver_price = Movie.SilverPrice;
            newMovie.gold_price = Movie.GoldPrice;
            newMovie.platinum_price = Movie.PlatinumPrice;

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
            return View(newMovie);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TicketDetailsViewModel movieBooking)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);


            if (ModelState.IsValid)
            {
                MovieBooking newmovieBooking = new MovieBooking();
                newmovieBooking.name = movieBooking.name;
                newmovieBooking.showtime = movieBooking.showTime;
                newmovieBooking.date = movieBooking.showDate;
                newmovieBooking.ticketType = movieBooking.ticketType;
                if(movieBooking.ticketType == "Silver")
                {
                    newmovieBooking.total = movieBooking.ticketNo * movieBooking.silver_price;
                }else if(movieBooking.ticketType == "Gold")
                {
                    newmovieBooking.total = movieBooking.ticketNo * movieBooking.gold_price;
                }
                else
                {
                    newmovieBooking.total = movieBooking.ticketNo * movieBooking.platinum_price;
                }
                newmovieBooking.total_tickets = movieBooking.ticketNo;

                newmovieBooking.AppUserId = _userManager.GetUserId(HttpContext.User);
               
                _movieBookingRepo.Add(newmovieBooking);

   
                return RedirectToAction("details", new { Id = newmovieBooking.Id });
            }
            return View();
        }
       
       

    }
}
