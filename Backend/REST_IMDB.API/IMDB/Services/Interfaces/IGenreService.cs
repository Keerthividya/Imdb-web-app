using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IGenreService
    {
        IList<GenreResponse> Get();
        GenreResponse Get(int id);
        int Create(GenreRequest genre);
        void Update(int id, GenreRequest genre);
        void Delete(int id);
    }
}
