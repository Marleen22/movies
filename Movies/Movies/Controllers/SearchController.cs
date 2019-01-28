using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

using Ogd.Movies.Web.Models;
using Ogd.Movies.Youtube.Models;
using Ogd.Movies;
using Ogd.Movies.Youtube;

namespace Ogd.Movies.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //POST: Search
        [HttpPost]
        public async Task<ActionResult> Index(SearchViewModel viewModel)
        {
            Omdb.OmdbApi omdbApi = new Omdb.OmdbApi();
            Youtube.YoutubeApi youtubeApi = new Youtube.YoutubeApi();

            var title = viewModel.Title;
            var keyOmdb = "df62845f";

            string uriOmdb = "http://www.omdbapi.com/?apikey="+keyOmdb+"&t="+title;
            string jobOmdb = Omdb.OmdbApi.doPUT(uriOmdb);

            Omdb.Models.Response responseOmdb = JsonConvert.DeserializeObject<Omdb.Models.Response>(jobOmdb);

            //TODO: Show info back on the screen
            //TODO: Check if something has found

            List<YoutubeMovie> youtubeMovies = await youtubeApi.GetYoutubeMovies(viewModel.Title);

            ResultViewModel resultViewModel = new ResultViewModel
            {
                Title = responseOmdb.Title,
                Year = responseOmdb.Year,
                YoutubeMovies = youtubeMovies
            };

            return View("Result", resultViewModel);
        }
    }
}