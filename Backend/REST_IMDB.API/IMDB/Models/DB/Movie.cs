namespace IMDB.Models.DB
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Producer { get; set; }
        public string CoverImage { get; set; }
    }
}
