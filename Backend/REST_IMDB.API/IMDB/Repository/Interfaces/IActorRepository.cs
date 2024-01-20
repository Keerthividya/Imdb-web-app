using System.Collections.Generic;
using IMDB.Models.DB;

namespace IMDB.Repository.Interfaces
{
    public interface IActorRepository
    {
        public IEnumerable<Actor> Get();
        public Actor Get(int id);
        public int Create(Actor actor);
        public void Update(int id,Actor actor);
        public void Delete(int id);
        public IEnumerable<Actor> GetByMovieId(int movieId);
    }
}
