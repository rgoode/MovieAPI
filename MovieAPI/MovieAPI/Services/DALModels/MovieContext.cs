using Microsoft.EntityFrameworkCore;
using MovieAPI.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MovieAPI.Services
{
    public class MovieContext : DbContext, IMovieContext 
    {
        public DbSet<Movie> Movies { get; set; }
        

        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        public IEnumerable<Movie> GetMoviesByCategory(string genre)
        {
            var dbMovies = Movies.Where(movie => movie.Genre == genre);
            return dbMovies;
        }
        public Movie GetRandomMovie()
        {
            var random = new Random();
            var count = Movies.Count();
            var skip = (int)( random.NextDouble() * count);  
            return Movies.Skip(skip).Take(1).First();
        }
        public Movie GetRandomByGenre(string genre)
        {
            var random = new Random();
            var count = Movies.Where(movie => movie.Genre == genre).Count();
            var skip = (int)(random.NextDouble() * count);
            return Movies.Where(movie => movie.Genre == genre).Skip(skip).Take(1).First();
        }

        //list of randoms
        public IEnumerable<Movie> GetRandomListMovies(int count)
        {
            var MovieList = new List<Movie>();
            for(int i = 0; i < count; i++)
                {
                    MovieList.Add(GetRandomMovie());
                
                }
            return MovieList;

        }
        public Movie GetMovie(int id)
        {
            var dbMovie = Movies.Find(id);

            return dbMovie;
        }

        public IEnumerable<string> GetCategories()
        {
           return Movies.Select(movie => movie.Genre);
        }

        public IEnumerable<Movie> GetMovieByKeyword(string keyWord)
        {
            return Movies.Where(movie => movie.Title.Contains(keyWord));
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Data Source=localhost;Initial Catalog=movieregistration;Integrated Security=True");
        }

        public Movie AddMovie(Movie movieTitle)
        {
            Movies.Add(movieTitle);
            SaveChanges();
            return movieTitle;

            
        }
    }
}
