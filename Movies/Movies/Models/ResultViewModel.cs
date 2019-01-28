using Ogd.Movies.Youtube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ogd.Movies.Web.Models
{
    public class ResultViewModel
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public List<YoutubeMovie> YoutubeMovies {get;set;} 
    }
}
