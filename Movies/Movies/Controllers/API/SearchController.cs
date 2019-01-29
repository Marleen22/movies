using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ogd.Movies.Web.Controllers.API
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet("{Title}", Name = "Get")]
        public async Task<string> GetAsync(string Title)
        {
            Api.WebApi webApi = new Api.WebApi();
            return await webApi.GetMovie(Title);
        }
    }
}