using IMDB.Models.DB;
using System.Collections.Generic;

namespace IMDB.Repository.Interfaces
{
    public interface IProducerRepository
    {
        public IEnumerable<Producer> Get();
        public Producer Get(int id);
        public int Create(Producer producer);
        public void Update(int id, Producer producer);
        public void Delete(int id);
    }
}
