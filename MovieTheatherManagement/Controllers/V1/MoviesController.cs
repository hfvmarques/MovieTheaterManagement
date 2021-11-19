using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(ApiRoutes.Movies.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _movieService.GetMoviesAsync());
        }

        [HttpPut(ApiRoutes.Movies.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid movieId, [FromBody] UpdateMovieRequest request)
        {
            var movie = new Movie
            { 
                Id = movieId,
                Image = request.Image,
                Title = request.Title,
                Description = request.Description
            };

            var updated = await _movieService.UpdateMovieAsync(movie);

            if (updated)
                return Ok(movie);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Movies.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid movieId)
        {
            var deleted = await _movieService.DeleteMovieAsync(movieId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Movies.Get)]
        public async Task<IActionResult> GetAsync([FromRoute]Guid movieId)
        {
            var movie = await _movieService.GetMovieByIdAsync(movieId);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost(ApiRoutes.Movies.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateMovieRequest movieRequest)
        {
            var movie = new Movie 
            { 
                Image = movieRequest.Image,
                Title = movieRequest.Title,
                Description = movieRequest.Description
            };

            await _movieService.CreateMovieAsync(movie);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Movies.Get.Replace("{movieId}", movie.Id.ToString());

            var response = new MovieResponse { Id = movie.Id };
            return Created(locationUri, response);
        }
    }
}
