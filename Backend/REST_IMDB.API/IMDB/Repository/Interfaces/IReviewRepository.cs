using IMDB.Models.DB;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> Get();
        public Review Get(int id);
        public int Create(Review review);
        public void Update(int id, Review review);
        public void Delete(int id);
    }
}
