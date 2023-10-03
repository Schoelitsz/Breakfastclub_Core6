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
            IEnumerable<Reservation> objReservationList = _context.Reservations;
            return View(objReservationList);
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

        /*public IActionResult Edit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return View("List");
            }

            return View();  //what happens here
        }*/

        public IActionResult Delete(int ID)
        {
            return RedirectToAction("List");
        }


        // to do: create not found page where they can return to list or go to create

    }
}


// to do: error if availableseats < obj.ReservationsSeats for that (time and) date return error