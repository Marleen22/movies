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
using Ogd.Movies.Omdb.Models;

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchViewModel viewModel)
        {
            Omdb.OmdbApi omdbApi = new Omdb.OmdbApi();
            Youtube.YoutubeApi youtubeApi = new Youtube.YoutubeApi();

            OmdbMovie omdbMovies = await omdbApi.GetOmdbMovie(viewModel.Title);
            List<YoutubeMovie> youtubeMovies = await youtubeApi.GetYoutubeMovies(viewModel.Title + "trailer");

            ResultViewModel resultViewModel = new ResultViewModel
            {
                Title = omdbMovies.Title,
                Year = omdbMovies.Year,
                Actors = omdbMovies.Actors,
                Genre = omdbMovies.Genre,
                Plot = omdbMovies.Plot,
                Language = omdbMovies.Language,
                Poster = omdbMovies.Poster,
                YoutubeMovies = youtubeMovies
            };

            return View("Result", resultViewModel);
        }
    }
}