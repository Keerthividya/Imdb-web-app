using System.Collections.Generic;
using IMDB.Models.Request;
using IMDB.Models.Response;

namespace IMDB.Services.Interfaces
{
    public interface IActorService
    {
        IList<ActorResponse> Get();
        ActorResponse Get(int id);
        int Create(ActorRequest actor);
        void Update(int id, ActorRequest actor);
        void Delete(int id);

    }
}
