using IMDB.Models.DB;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> Get();
        public Movie Get(int id);
        public int Create(Movie movie,List<int>actors,List<int>genre);
        public void Update(int MovieId, Movie movie, List<int> actors, List<int> genre);
        public void Delete(int id);
    }
}
