using BreakfastClub.Data;
using BreakfastClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakfastClub.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<MenuItem> objMenuItemList = _context.MenuItems;
            return View(objMenuItemList);
        }

        public IActionResult Menu()
        {
            IEnumerable<MenuItem> objMenuItemList = _context.MenuItems;
            return View(objMenuItemList);
        }

        //GET
        public IActionResult Edit(int Id)
        {
            var MenuItem = _context.MenuItems.FirstOrDefault(x => x.Id == Id);

            if (MenuItem == null)
            {
                return NotFound();
            }
            return View(MenuItem);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MenuItem editedMenuItem)
        {
            if (ModelState.IsValid)
            {
                var existingMenuItem = _context.MenuItems.FirstOrDefault(m => m.Id == editedMenuItem.Id);
                if (existingMenuItem == null) { 
                    return NotFound();
                }

                existingMenuItem.Name = editedMenuItem.Name;
                existingMenuItem.Description = editedMenuItem.Description;
                existingMenuItem.Price = editedMenuItem.Price;
                existingMenuItem.Course = editedMenuItem.Course;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editedMenuItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem obj)
        {
            if (ModelState.IsValid)
            {
                _context.MenuItems.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public IActionResult Delete(int Id)
        {
            var menuItemToDelete = _context.MenuItems.Find(Id);

            if (menuItemToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.MenuItems.Remove(menuItemToDelete);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
