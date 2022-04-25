using MovieAPI.Controllers;
using MovieAPI.Model;
using System.Collections.Generic;

namespace MovieAPI
{
    public interface IMovieContext 
    {
        public IEnumerable<Movie> GetMovies();


        public IEnumerable<Movie> GetMoviesByCategory(string genre);

        public Movie GetRandomMovie();

        public Movie GetRandomByGenre(string genre);


        //list of randoms
        public IEnumerable<Movie> GetRandomListMovies(int count);

        public Movie GetMovie(int id);


        public IEnumerable<string> GetCategories();


        public IEnumerable<Movie> GetMovieByKeyword(string keyWord);
        public Movie AddMovie(Movie movieTitle);
    }




}