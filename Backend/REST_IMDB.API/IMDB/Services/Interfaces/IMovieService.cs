using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IMovieService
    {
        IList<MovieResponse> Get();
        MovieResponse Get(int id);
        int Create(MovieRequest movie);
        void Update(int id,MovieRequest movie);
        void Delete(int id);
    }
}
