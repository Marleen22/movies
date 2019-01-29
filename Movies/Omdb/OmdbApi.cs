using System.Threading.Tasks;

using IMDBCore;

using Ogd.Movies.Omdb.Models;

namespace Ogd.Movies.Omdb
{
    public class OmdbApi
    {
        public async Task<OmdbMovie> GetOmdbMovie(string searchString)
        {
            string apiKey = "df62845f";

            var imdb = new Imdb(apiKey);
            var movie = await imdb.GetMovieAsync(searchString);

            OmdbMovie omdbMovie = new OmdbMovie
            {
                Title = movie.Title,
                Year = movie.Year,
                Actors = movie.Actors,
                Genre = movie.Genre,
                Plot = movie.Plot,
                Language = movie.Language,
                Poster = movie.Poster
            };

            return omdbMovie;
        }
    }
}
