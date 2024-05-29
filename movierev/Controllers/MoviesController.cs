using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using movierev.Models;

namespace movierev.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies

       // [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index()
        {
            // Get the current user's ID
            var userId = User.Identity.GetUserId();

            // Filter movies by the current user's ID
            var userMovies = db.Movies.Where(m => m.UserId == userId).ToList();

            return View(userMovies);

        }

        // GET: Movies/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Image,Rating,ReleaseYear,Duration")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.UserId = User.Identity.GetUserId();
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Image,Rating,ReleaseYear,Duration")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Attach the existing movie entity to the context and mark it as modified
                var existingMovie = db.Movies.Find(movie.Id);
                if (existingMovie != null)
                {
                    existingMovie.Title = movie.Title;
                    existingMovie.Description = movie.Description;
                    existingMovie.Image = movie.Image;
                    existingMovie.Rating = movie.Rating;
                    existingMovie.ReleaseYear = movie.ReleaseYear;
                    existingMovie.Duration = movie.Duration;

                    db.Entry(existingMovie).State = EntityState.Modified;
                    db.SaveChanges(); // Save the changes
                    return RedirectToAction("Index"); // Redirect to Index
                }
                return HttpNotFound(); // Return not found if movie does not exist
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
       // [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
