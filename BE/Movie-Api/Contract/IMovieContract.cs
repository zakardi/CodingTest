using MoviesApi.Model;

namespace MoviesApi.Contract
{
    public interface IMovieContract
    {
        public MoviesDTO GetMovies();
    }
}
