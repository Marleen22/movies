using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Newtonsoft.Json;
using Omdb;
using Data.Models;

namespace Movies.Controllers
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
            //TODO: Create correct link
            string uri = "http://www.omdbapi.com/?apikey=df62845f&t=titanic";
            string job = OmdbApi.doPUT(uri);

            Omdb.Models.Response response = JsonConvert.DeserializeObject<Omdb.Models.Response>(job);

            return View(viewModel);
        }
    }
}