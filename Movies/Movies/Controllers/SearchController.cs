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
using Ogd.Movies.Omdb;


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
        public ActionResult Index(SearchViewModel viewModel)
        {
            var title = viewModel.Title;
            var keyOmdb = "df62845f";

            string uriOmdb = "http://www.omdbapi.com/?apikey="+keyOmdb+"&t="+title;
            string jobOmdb = OmdbApi.doPUT(uriOmdb);

            Omdb.Models.Response responseOmdb = JsonConvert.DeserializeObject<Omdb.Models.Response>(jobOmdb);
            //TODO: Show info back on the screen
            //TODO: Check if something has found
            //if (response == null)
            //    return HttpNotFound();
            var apiKey = "AIzaSyBsS7lz-5DvzlOdlJP_KsAuY4kM8NnvCJU";
            var maxResults = 1;
            var part = "snippet";

            string uriYoutube = "https://www.googleapis.com/youtube/v3/search?part="+part+"&maxResults="+maxResults+"&key="+apiKey+"&q="+title;
            string jobYoutube = Youtube.YoutubeApi.doPUT(uriYoutube);

            Youtube.Models.Response responseYoutube = JsonConvert.DeserializeObject<Youtube.Models.Response>(jobYoutube);

            return RedirectToAction("Result", "Search", new { title = responseOmdb.Title, year = responseOmdb.Year});
        }

        // GET: Result
        public ActionResult Result(string title, string year)
        {
            //TODO Create model and get data from the model
            ViewBag.Title = title;
            ViewBag.Year = year;

            var movielink = "1_INNPR84CI";
            ViewBag.Movie = "https://www.youtube.com/embed/"+movielink;
            return View();
        }
    }
}