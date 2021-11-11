using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIE_BOOKING_CORE.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        public DbSet<MovieTicket> MovieTickets { get; set; }
        public DbSet<MovieBooking> MovieBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieBooking>()
                .HasOne<AppUser>(b => b.AppUser).
                WithMany(m => m.Bookings).
                HasForeignKey(m => m.AppUserId);
               
        }

    }
}
