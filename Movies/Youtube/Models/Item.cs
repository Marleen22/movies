using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ogd.Movies.Youtube.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public Id Id { get; set; }
    }
}
