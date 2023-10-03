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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation obj)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Index", "Home", obj);

        }

        public IActionResult Success(int Id)
        {
            return View();
        }

        public IActionResult List()
        {
            var reservations = _context.Reservations.OrderBy(r => r.Date).ToList();

            return View(reservations);
        }

        public IActionResult Details(int ID)
        {
            var ReservationDetails = _context.Reservations.Find(ID);
            return View(ReservationDetails);
        }


        //GET
        public IActionResult Edit(int ID)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.ID == ID);

            if (reservation == null)
            {
                return NotFound(); 
            }

            return View(reservation);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation editedReservation)
        {
            if (ModelState.IsValid)
            {
               
                var existingReservation = _context.Reservations.FirstOrDefault(r => r.ID == editedReservation.ID);

                if (existingReservation == null)
                {
                    return NotFound(); 
                }

                existingReservation.Name = editedReservation.Name;
                existingReservation.ReservationSeats = editedReservation.ReservationSeats;
                existingReservation.Date = editedReservation.Date;

                _context.SaveChanges(); 

                return RedirectToAction("List"); 
            }

            return View(editedReservation); 
        }


        public IActionResult Delete(int ID)
        {
            var reservationToDelete = _context.Reservations.Find(ID);

            if (reservationToDelete != null)
            {
                
                _context.Reservations.Remove(reservationToDelete);
                _context.SaveChanges();

                
                return RedirectToAction("List");
            }
            else
            {
                return NotFound();
            }
        }


        // to do: create proper not found userflow

    }
}


// to do: error if availableseats < obj.ReservationsSeats for that (time and) date return error
// to do: confirmation bubble for deleting