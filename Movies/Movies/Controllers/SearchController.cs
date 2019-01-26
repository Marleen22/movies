using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
    }
}