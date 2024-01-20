using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IReviewService
    {
        IList<ReviewResponse> Get(int movieId);
        ReviewResponse Get(int movieId, int id);
        int Create(int movieId,ReviewRequest review);
        void Update(int movieId,int id, ReviewRequest review);
        void Delete(int movieId, int id);
    }
}
