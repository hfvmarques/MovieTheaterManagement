using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieByIdAsync(Guid movieId);

        Task<bool> CreateMovieAsync(Movie movie);

        Task<bool> UpdateMovieAsync(Movie movieToUpdate);

        Task<bool> DeleteMovieAsync(Guid movieId);
    }
}
