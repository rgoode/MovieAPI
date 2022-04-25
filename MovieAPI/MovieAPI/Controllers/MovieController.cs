using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model;
using MovieAPI.Services;
using MovieAPI.Services.DALModels;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieContext _movieContext;

        public MovieController(IMovieContext movieContext)
        {
            _movieContext = movieContext;
        }


        //List all movies 
        [HttpGet]
        [Route("AllMovies")]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieContext.GetMovies());
        }

        //movie by category
        [HttpGet]
        [Route("MoviesByCategory")]
        public IActionResult GetMoviesByCategory([FromQuery] string Genre)
        {
            var movie = _movieContext.GetMoviesByCategory(Genre);
            return Ok(movie);
        }

        //random movie selection
        [HttpGet]
        [Route("RandomMovieSelection")]
        public IActionResult GetRandomMovies()
        {

            return Ok(_movieContext.GetRandomMovie());
        }

        //random by genre
        [HttpGet]
        [Route("movieGenre")]
        public IActionResult GetRandomByGenre([FromQuery] string Genre)
        {
            //enum Genre = new enum[] { "Horror", "Comedy", "Action", "Animated", "Romance", "SciFi" };
            var movie = _movieContext.GetRandomByGenre(Genre);
            if(movie == null)
            {
                return NotFound("Option enteres was not found");
            }
            return Ok(movie);
        }

        //list of randoms
        [HttpGet]
        [Route("randomMovieList")]
        public IActionResult GetRandomListOfMovies([FromQuery] int count)
        {
            if(count < 0)
            {
                return BadRequest("Please enter a positive/whole number");
            }

            return Ok(_movieContext.GetRandomListMovies(count));
        }

        //list of categories
        [HttpGet]
        [Route("genreList")]
        public IActionResult GetCategoryList()
        {
            return Ok(_movieContext.GetCategories());

        }

        //Title Keyword
        [HttpGet]
        [Route("titleKeyword")]
        public IActionResult GetMovieByKeyWord([FromQuery] string keyWord)
        {
            return Ok(_movieContext.GetMovieByKeyword(keyWord));

        }

        [HttpGet]
        [Route("movieTitle")]
        public IActionResult GetMovie([FromRoute] int Id)
        {
            var movie = _movieContext.GetMovie(Id);

            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound("Movie was not found.");
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] AddMovie Title)
        {
            var movieTitle = new Movie();
            movieTitle.Title = Title.Title;

            var dbMovie = _movieContext.AddMovie(movieTitle);
            //dbMovie.SaveChanges();
            

            return Created($"https://localhost:5001/{dbMovie.Title}", dbMovie);
        }




    }
}
