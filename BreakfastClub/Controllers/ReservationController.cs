using BreakfastClub.Data;
using BreakfastClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakfastClub.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {   
            _context = context;
        }
        public IActionResult Index()
        {   
            IEnumerable<Reservation> objReservationList = _context.Reservations;
            return View(objReservationList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation obj)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(obj);
                _context.SaveChanges();
                return View("Success");
            }
                
            return View("Index");
               
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}


// to do: error if availableseats < obj.ReservationsSeats (for that time and date) return error