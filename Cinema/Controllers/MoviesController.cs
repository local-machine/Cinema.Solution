using Microsoft.AspNetCore.Mvc;
using Cinema.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinemaContext _db;

        public MoviesController(CinemaContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Movie> model = _db.Movies.Include(movies => movies.Genre).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Movie thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
            return View(thisMovie);
        }

        public ActionResult Edit(int id)
        {
            var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
            return View(thisMovie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
            return View(thisMovie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
            _db.Movies.Remove(thisMovie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}