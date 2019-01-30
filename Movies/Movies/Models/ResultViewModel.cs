using System.Collections.Generic;

using Ogd.Movies.Youtube.Models;

namespace Ogd.Movies.Web.Models
{
    public class ResultViewModel
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string Actors { get; set; }

        public string Genre { get; set; }

        public string Plot { get; set; }

        public string Language { get; set; }

        public string Poster { get; set; }

        public List<YoutubeMovie> YoutubeMovies {get;set;} 
    }
}
