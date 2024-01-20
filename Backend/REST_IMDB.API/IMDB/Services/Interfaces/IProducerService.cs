using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Services.Interfaces
{
    public interface IProducerService
    {
        IList<ProducerResponse> Get();
        ProducerResponse Get(int id);
        int Create(ProducerRequest producer);
        void Update(int id, ProducerRequest producer);
        void Delete(int id);
    }
}
