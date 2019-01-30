using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Ogd.Movies.Data.Models;
using Ogd.Movies.Omdb.Models;
using Ogd.Movies.Youtube.Models;

namespace Ogd.Movies.Api
{
    public class WebApi
    {
        public async Task<string> GetMovie(string SearchString)
        {
            Omdb.OmdbApi omdbApi = new Omdb.OmdbApi();
            Youtube.YoutubeApi youtubeApi = new Youtube.YoutubeApi();

            OmdbMovie omdbMovie = await omdbApi.GetOmdbMovie(SearchString);
            List<YoutubeMovie> youtubeMovie = await youtubeApi.GetYoutubeMovies(SearchString);

            Movie movie = new Movie
            {
                OmdbMovie = omdbMovie,
                YoutubeMovie = youtubeMovie
            };

            return JsonConvert.SerializeObject(movie);
        }


    }
}
