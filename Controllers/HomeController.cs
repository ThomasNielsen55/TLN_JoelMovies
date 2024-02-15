using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Diagnostics;
using TLN_JoelMovies.Models;

namespace TLN_JoelMovies.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private MovieContext _context;

        public HomeController(MovieContext movie)
        {
            _context = movie;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MeetJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(Movie m) 
        {
            if(m.lent == null) { m.lent = ""; }
            if (m.notes == null) { m.notes = ""; }
            if (m.subcategory == null) { m.subcategory = ""; }


            _context.Movies.Add(m);
            _context.SaveChanges();

            return View("Confirmation", m);
        }

    }
}
