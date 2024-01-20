using System;
using System.Collections.Generic;
using System.Linq;
using IMDB.Models.DB;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repository.Interfaces;
using IMDB.Services.Interfaces;

namespace IMDB.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;


        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;

        }

        public IList<ActorResponse> Get()
        {
            var actors = _actorRepository.Get();
            if (!actors.Any())
            {
                throw new ArgumentNullException("Actors", "Actors cannot be Null");
            }
            var actorResponse = actors.Select(x => new ActorResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Bio = x.Bio,
                DOB = x.DOB,
                Gender = x.Gender,
                Image= x.Image,
            }).ToList();
            return actorResponse;
        }

        public ActorResponse Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }

            Actor actor = _actorRepository.Get().FirstOrDefault(a=>a.Id==id);
            if (actor == null)
            {
                throw new ArgumentNullException("Id", $"Actor {id} is Null");
            }
            var actorResponse = new ActorResponse()
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                DOB = actor.DOB,
                Gender = actor.Gender,
                Image = actor.Image,
            };

            return actorResponse;

        }
        public int Create(ActorRequest actorRequest)
        {
            if (string.IsNullOrEmpty(actorRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Actor Name");
            }
            else if (string.IsNullOrEmpty(actorRequest.Bio))
            {
                throw new ArgumentException("Invalid arguments in Actor Bio");
            }
            else if (actorRequest.DOB > DateTime.Now)
            {
                throw new ArgumentException("Invalid arguments in Actor DOB");
            }
            else if (string.IsNullOrEmpty(actorRequest.Gender))
            {
                throw new ArgumentException("Invalid arguments in Actor Gender");
            }
            Actor actor = new Actor()
            {
                Id = actorRequest.Id,
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Gender = actorRequest.Gender,
                Image = actorRequest.Image,
            };
            try
            {
                var id = _actorRepository.Create(actor);
                return id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(int id, ActorRequest actorRequest)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            else if (string.IsNullOrEmpty(actorRequest.Name))
            {
                throw new ArgumentException("Invalid arguments in Actor Name");
            }
            else if (string.IsNullOrEmpty(actorRequest.Bio))
            {
                throw new ArgumentException("Invalid arguments in Actor Bio");
            }
            else if (actorRequest.DOB > DateTime.Now)
            {
                throw new ArgumentException("Invalid arguments in Actor DOB");
            }
            else if (string.IsNullOrEmpty(actorRequest.Gender))
            {
                throw new ArgumentException("Invalid arguments in Actor Gender");
            }
            else if (_actorRepository.Get().FirstOrDefault(a => a.Id == id) == null)
            {
                throw new ArgumentNullException("Id", $"Actor {id} is Null");
            }

            Actor actor = new Actor()
            {
                Id = actorRequest.Id,
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Gender = actorRequest.Gender,
                Image= actorRequest.Image,
            };
            try
            {
                _actorRepository.Update(id, actor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            Actor actor = _actorRepository.Get().FirstOrDefault(a => a.Id == id);
            if (actor == null)
            {
                throw new ArgumentNullException("Id", $"Actor {id} is Null");
            }
            _actorRepository.Delete(id);

        }
    }
}
