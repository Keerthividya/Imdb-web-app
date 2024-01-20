using IMDB.Models.DB;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> Get();
        public Genre Get(int id);
        public int Create(Genre genre);
        public void Update(int id, Genre genre);
        public void Delete(int id);
        public IEnumerable<Genre> GetByMovieId(int movieId);
    }
}
