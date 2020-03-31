using System.Collections.Generic;
using System.Linq;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            this._context = context;
        }

        public void AddMovie(Movie movie)
        {
            var newMovie = new Movie() {
                Id = movie.Id,
                Title = movie.Title,
                Price = movie.Price
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }

        public Movie FindById(int? id)
        {
            if (id == null) 
            {
                return null;
            }
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }


        public IEnumerable<Movie> getAll()
        {
             return _context.Movies.ToList();
        }

        public void remove(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public bool MovieExists(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            return movie != null ? true : false;
        }
    }
}