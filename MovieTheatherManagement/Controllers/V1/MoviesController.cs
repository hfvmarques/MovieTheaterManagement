using Microsoft.AspNetCore.Mvc;
using MovieTheatherManagement.Contracts;
using MovieTheatherManagement.Contracts.V1;
using MovieTheatherManagement.Contracts.V1.Requests;
using MovieTheatherManagement.Contracts.V1.Responses;
using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Controllers.V1
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies;

        public MoviesController()
        {
            _movies = new List<Movie>();
            for (var i=0; i<5;i++)
            {
                _movies.Add(new Movie { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Movies.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_movies);
        }

        [HttpPost(ApiRoutes.Movies.Create)]
        public IActionResult Create([FromBody] CreateMovieRequest movieRequest)
        {
            var movie = new Movie { Id = movieRequest.Id };

            if (string.IsNullOrEmpty(movie.Id))
                movie.Id = Guid.NewGuid().ToString();

            _movies.Add(movie);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Movies.Get.Replace("{movieId}", movie.Id);

            var response = new MovieResponse { Id = movie.Id };
            return Created(locationUri, response);
        }
    }
}
