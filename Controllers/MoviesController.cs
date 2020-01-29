using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using System.Linq;
using Vidly.ViewModels;
using System;
using System.IO;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                if (movie.File != null && movie.File.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("/Content/img/movies"),
                                               Path.GetFileName(movie.File.FileName));
                    movie.File.SaveAs(path);
                    
                    string pathFormatted =  path.Replace(@"\", "/");

                    pathFormatted = pathFormatted.Substring(pathFormatted.IndexOf("/Content")).Trim();

                    movie.ImageURL = pathFormatted;
                }

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var MovieFormViewModel = new MovieFormViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };

            return View("New", MovieFormViewModel);
        }

        public ViewResult CardView()
        {
            var movies = _context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();

            return View(movies);
        }
    }
}