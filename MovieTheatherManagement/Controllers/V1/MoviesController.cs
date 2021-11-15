using Microsoft.AspNetCore.Mvc;
using MovieTheatherManagement.Contracts;
using MovieTheatherManagement.Contracts.V1;
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
    }
}
