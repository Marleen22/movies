using System.Collections.Generic;
using System.Threading.Tasks;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;

using Ogd.Movies.Youtube.Models;

namespace Ogd.Movies.Youtube
{
    public class YoutubeApi
    {
        public async Task<List<YoutubeMovie>> GetYoutubeMovies(string searchString)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBsS7lz-5DvzlOdlJP_KsAuY4kM8NnvCJU",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchString; // Replace with your search term.
            searchListRequest.MaxResults = 3;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<YoutubeMovie> youtubeMovies = new List<YoutubeMovie>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                if (searchResult.Id.Kind == "youtube#video")
                {
                    youtubeMovies.Add(new YoutubeMovie
                    {
                        Title = searchResult.Snippet.Title,
                        VideoId = searchResult.Id.VideoId
                    });
                }
            }
            return youtubeMovies;
        }
    }
}
