using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApi.Contract;
using System;
using System.Net;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieContract _movieContract;

        private readonly ILogger<MoviesController> _logger;
        public MoviesController(ILogger<MoviesController> logger , IMovieContract movieContract)
        {
            _logger = logger;
            _movieContract = movieContract;
        }


        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                var movies = _movieContract.GetMovies();
                return Ok(movies);
            }
            catch (Exception exception)
            {
                _logger.LogError("Throwing error while fetching movies", exception);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
}
}