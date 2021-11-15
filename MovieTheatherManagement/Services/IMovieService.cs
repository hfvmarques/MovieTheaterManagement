using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        Movie GetMovieById(Guid movieId);

        bool UpdateMovie(Movie movieToUpdate);

        bool DeleteMovie(Guid movieId);
    }
}
