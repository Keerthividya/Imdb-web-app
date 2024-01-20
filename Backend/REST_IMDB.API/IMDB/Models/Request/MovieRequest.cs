using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models.Request
{
    public partial class MovieRequest
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public List<int> Actors { get; set; }
        public List<int> Genre { get; set; }
        public string Producer { get; set; }
        public string CoverImage { get; set; }
    }
}
