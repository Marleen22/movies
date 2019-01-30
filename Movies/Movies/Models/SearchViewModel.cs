using System.ComponentModel.DataAnnotations;

namespace Ogd.Movies.Web.Models
{
    public class SearchViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
