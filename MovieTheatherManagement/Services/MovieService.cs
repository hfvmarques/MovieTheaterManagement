using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> _movies;

        public MovieService()
        {
            _movies = new List<Movie>();
            for (var i = 0; i < 5; i++)
            {
                _movies.Add(new Movie
                {
                    Id = Guid.NewGuid(),
                    Image = Guid.NewGuid().ToString(),
                    Title = Guid.NewGuid().ToString(),
                    Description = Guid.NewGuid().ToString(),
                    Duration = new TimeSpan(1, 30, 0)
                });
            }
        }

        public Movie GetMovieById(Guid movieId)
        {
            return _movies.SingleOrDefault(x => x.Id == movieId);
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public bool UpdateMovie(Movie movieToUpdate)
        {
            var exists = GetMovieById(movieToUpdate.Id) != null;

            if (!exists)
                return false;

            var index = _movies.FindIndex(x => x.Id == movieToUpdate.Id);
            _movies[index] = movieToUpdate;
            return true;
        }
    }
}
