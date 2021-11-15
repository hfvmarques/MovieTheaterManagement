using Microsoft.AspNetCore.Mvc;
using MovieTheatherManagement.Contracts;
using MovieTheatherManagement.Contracts.V1;
using MovieTheatherManagement.Contracts.V1.Requests;
using MovieTheatherManagement.Contracts.V1.Responses;
using MovieTheatherManagement.Domain;
using MovieTheatherManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Controllers.V1
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(ApiRoutes.Movies.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetMovies());
        }

        [HttpPut(ApiRoutes.Movies.Update)]
        public IActionResult Update([FromRoute] Guid movieId, [FromBody] UpdateMovieRequest request)
        {
            var movie = new Movie
            { 
                Id = movieId,
                Image = request.Image,
                Title = request.Title,
                Description = request.Description,
                Duration = request.Duration
            };

            var updated = _movieService.UpdateMovie(movie);

            if (updated)
                return Ok(movie);

            return NotFound();
        }

        [HttpGet(ApiRoutes.Movies.Get)]
        public IActionResult Get([FromRoute]Guid movieId)
        {
            var movie = _movieService.GetMovieById(movieId);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost(ApiRoutes.Movies.Create)]
        public IActionResult Create([FromBody] CreateMovieRequest movieRequest)
        {
            var movie = new Movie { Id = movieRequest.Id };

            if (movie.Id != Guid.Empty)
                movie.Id = Guid.NewGuid();

            _movieService.GetMovies().Add(movie);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Movies.Get.Replace("{movieId}", movie.Id.ToString());

            var response = new MovieResponse { Id = movie.Id };
            return Created(locationUri, response);
        }
    }
}
