using Ogd.Movies.Omdb.Models;
using Ogd.Movies.Youtube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogd.Movies.Data.Models
{
    public class Movie
    {
        public OmdbMovie OmdbMovie { get; set; }

        public List<YoutubeMovie> YoutubeMovie { get; set; }
    }
}
