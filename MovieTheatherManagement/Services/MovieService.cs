using Microsoft.EntityFrameworkCore;
using MovieTheatherManagement.Data;
using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _dataContext;
        public MovieService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await _dataContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(Guid movieId)
        {
            return await _dataContext.Movies.SingleOrDefaultAsync(x => x.Id == movieId);
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            await _dataContext.Movies.AddAsync(movie);
            var createdMovie = await _dataContext.SaveChangesAsync();
            return createdMovie > 0;
        }

        public async Task<bool> UpdateMovieAsync(Movie movieToUpdate)
        {
            _dataContext.Movies.Update(movieToUpdate);
            var updatedMovie = await _dataContext.SaveChangesAsync();
            return updatedMovie > 0;
        }

        public async Task<bool> DeleteMovieAsync(Guid movieId)
        {
            var movie = await GetMovieByIdAsync(movieId);

            if (movie == null)
                return false;

            _dataContext.Movies.Remove(movie);
            var deletedMovie = await _dataContext.SaveChangesAsync();
            return deletedMovie > 0;
        }
    }
}
