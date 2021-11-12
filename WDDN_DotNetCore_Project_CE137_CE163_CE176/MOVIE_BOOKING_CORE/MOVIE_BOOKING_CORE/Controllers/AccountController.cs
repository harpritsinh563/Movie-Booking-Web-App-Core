using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MOVIE_BOOKING_CORE.Models;
using MOVIE_BOOKING_CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Controllers
{
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private AppDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,AppDbContext context)
        {
            this._context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        [HttpPost]
        public async Task<IActionResult> Logout ()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "MovieTicket");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("index","Account");
        }

        [HttpGet]
        public IActionResult ViewBookings() 
        {
            string userId = userManager.GetUserId(HttpContext.User);
            var bookings = _context.MovieBookings.Where(a => a.AppUserId == userId);
            Console.WriteLine(bookings);
            foreach(var booking in bookings)
            {
                Console.WriteLine(booking.name);
            }
            return View(bookings);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.username, model.password,model.rememberMe,false);
                if (result.Succeeded)
                {
                    //string username = HttpContext.User.Identity.Name;
                    //Console.WriteLine("THIS IS USERNAME : "+username);
                    return RedirectToAction("index", "MovieTicket");
                }               
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View(model);
        }
    }
}
