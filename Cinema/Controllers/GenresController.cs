using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class GenresController : Controller
    {
        private readonly CinemaContext _db;
        public GenresController(CinemaContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Genre> model = _db.Genres.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
            return View(thisGenre);
        }

        public ActionResult Edit(int id)
        {
            var thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
            return View(thisGenre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
            return View(thisGenre);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
            _db.Genres.Remove(thisGenre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
