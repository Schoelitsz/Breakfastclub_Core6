using BreakfastClub.Data;
using System.Linq;

namespace BreakfastClub.Models
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            // Seed Reservations if the table is empty
            if (!_dbContext.Reservations.Any())
            {
                _dbContext.Reservations.AddRange(SeedReservations());
            }

            // Seed MenuItems if the table is empty
            if (!_dbContext.MenuItems.Any())
            {
                _dbContext.MenuItems.AddRange(SeedMenu());
            }

            // Seed Booths if the table is empty
            if (!_dbContext.Booths.Any())
            {
                _dbContext.Booths.AddRange(SeedBooths());
            }

            _dbContext.SaveChanges(); // Save changes to the database
        }

        public List<Reservation> SeedReservations()
        {
            // Your logic for seeding Reservations
            return new List<Reservation>
            {
                // Add your seed data here
                new Reservation { ID = 1, Name = "John Doe", Date = DateTime.Now }
            };
        }

        public List<MenuItem> SeedMenu()
        {
            // Your logic for seeding MenuItems
            return new List<MenuItem>
            {
                // Add your seed data here
                new MenuItem { Id = 1, Name = "Pancakes", Price = 9 }
            };
        }

        public List<Booth> SeedBooths()
        {
            // Your logic for seeding Booths
            return new List<Booth>
            {
                // Add your seed data here
                new Booth { Id = 1, BoothNumber = 1, Seats = 4 }
            };
        }
    }
}
