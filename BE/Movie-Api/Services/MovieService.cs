using MoviesApi.Contract;
using MoviesApi.Model;
using System.IO;
using System.Text.Json;

namespace MoviesApi.Services
{
    public class MovieService: IMovieContract
    {
        public MoviesDTO GetMovies()
        {
            var json = File.ReadAllText("Data\\movies.json");
            var listOfMovies = JsonSerializer.Deserialize<MoviesDTO>(json);
            return listOfMovies;
        }
    }
}
