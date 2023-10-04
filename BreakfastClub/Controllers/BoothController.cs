using BreakfastClub.Data;
using BreakfastClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreakfastClub.Controllers
{
    public class BoothController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BoothController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            IEnumerable<Booth> objBoothList = _context.Booths;
            return View(objBoothList);
        
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();  
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Assign()
        {
            return View();
        }
        
    }
}
