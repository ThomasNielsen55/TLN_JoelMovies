using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            ViewBag.categories = _context.Categories.ToList();

            return View("Submit", new Movie());
        }
        [HttpPost]
        public IActionResult Submit(Movie m)
        {
            if(m.CategoryID == null)
            {
                ViewBag.categories = _context.Categories.ToList();
                return View(m);
            }
            if (ModelState.IsValid)
            {
                _context.Movies.Add(m);
                _context.SaveChanges();

                return View("Confirmation", m);
            }
            else
            {
                ViewBag.categories = _context.Categories.ToList();
                return View(m);
            }
        }

        public IActionResult ShowMovies()
        {
            var movies = _context.Movies.Include("Category").ToList();


            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _context.Movies
                .Single(x => x.movieID == id);

            ViewBag.categories = _context.Categories.ToList();
            return View("Submit", record);
        }
        [HttpPost]
        public IActionResult Edit(Movie updated) 
        {
            _context.Update(updated);
            _context.SaveChanges();
            return RedirectToAction("ShowMovies");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _context.Movies
                .Single(x => x.movieID == id);

            return View(record);
        }
        [HttpPost]
        public IActionResult Delete(Movie record)
        {
            _context.Movies.Remove(record);
            _context.SaveChanges();

            return RedirectToAction("ShowMovies");
        }
    }
}
