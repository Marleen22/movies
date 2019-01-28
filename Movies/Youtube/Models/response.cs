using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogd.Movies.Youtube.Models
{
    public class Response
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
