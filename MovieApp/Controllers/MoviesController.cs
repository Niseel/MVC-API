using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly MovieContext _context;
        private readonly IMovieService _service;

        // public MoviesController(MovieContext context)
        // {
        //     _context = context;
        // }

        public MoviesController(IMovieService service)
        {
            this._service = service;
        }

        // GET: Movies
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Movies.ToListAsync());
        // }
        public IActionResult Index() 
        {
            var movies = _service.getAll();
            return View(movies);    
        }

        // GET: Movies/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var movie = await _context.Movies
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (movie == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(movie);
        // }
        public IActionResult Details(int? id) 
        {
            var movie = _service.FindById(id);
            if (movie == null) 
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            var movie = _service.FindById(id);
            if (movie == null) 
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            var movie = _service.FindById(id);
            if (movie == null) 
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _service.FindById(id);
            _service.remove(movie);
            return RedirectToAction(nameof(Index));
        }

    //     private bool MovieExists(int id)
    //     {
    //         return _context.Movies.Any(e => e.Id == id);
    //     }
    }
}

