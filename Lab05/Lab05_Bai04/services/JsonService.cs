using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MovieBookingApp.Models;

namespace MovieBookingApp.Services
{
    public static class JsonService
    {
        public static void SaveMovies(List<Movie> movies)
        {
            File.WriteAllText("movies.json", JsonConvert.SerializeObject(movies, Formatting.Indented));
        }
    }
}
