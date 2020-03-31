using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> getAll();
        Movie FindById(int? id);
        void remove(Movie movie);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        bool MovieExists(int id);

    }
}