using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreakfastClub.Models;

namespace BreakfastClub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Booth> Booths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the table schemas
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Booth>().ToTable("Booths");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");

            // Remove seeding from here
        }
    }
}
