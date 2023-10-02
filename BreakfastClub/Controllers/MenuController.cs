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
            return View();
        }

        public IActionResult Menu()
        {
            IEnumerable<MenuItem> objMenuItemList = _context.MenuItems;
            return View(objMenuItemList);
        }
    }
}
