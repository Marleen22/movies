using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogd.Movies.Youtube.Models
{
    public class Id
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }
}
