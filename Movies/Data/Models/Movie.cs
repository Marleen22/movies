using System.Collections.Generic;

using Ogd.Movies.Omdb.Models;
using Ogd.Movies.Youtube.Models;

namespace Ogd.Movies.Data.Models
{
    public class Movie
    {
        public OmdbMovie OmdbMovie { get; set; }

        public List<YoutubeMovie> YoutubeMovie { get; set; }
    }
}
