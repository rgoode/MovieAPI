using System;

namespace MovieAPI.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
