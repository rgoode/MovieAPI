using System.Collections.Generic;

namespace MovieAPI.Services.DALModels
{
    public class MovieProps
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }

        public enum Genre
        {
            Horror,
            Comedy,
            Action,
            Animated,
            Romance,
            SciFi
        }
    }
}
