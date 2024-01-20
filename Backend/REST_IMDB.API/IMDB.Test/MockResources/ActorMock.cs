using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;

namespace IMDB.Test.MockResources
{
    public class ActorMock
    {
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        private static readonly IEnumerable<Actor> ListOfActors = new List<Actor>
        {
             new Actor
                {
                    Id = 1,
                    Name = "Actor 1",
                    Bio = "--",
                    DOB = new DateTime(1990,4,1),
                    Gender="Male",
                    Image=""
                },
                new Actor
                {
                    Id = 2,
                    Name = "Actor ",
                    Bio = "--",
                    DOB = new DateTime(1997,4,2),
                    Gender="Female",
                    Image=""
                },
        };

        public static void MockGetAll()
        {
            ActorRepoMock.Setup(x => x.Get()).Returns(ListOfActors);
          
        }
        public static void MockGet(int id)
        {
            ActorRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(ListOfActors.FirstOrDefault(a=>a.Id==id));
        }

        public static void MockUpdate(int id,Actor actor)
        {
            ActorRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Actor>()));
                         
        }

        public static void MockCreate(Actor actor)
        {
            ActorRepoMock.Setup(x => x.Create(It.IsAny<Actor>())).Returns(3);

        }

        public static void MockDelete(int id)
        {
            ActorRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
                        
        }

        public static void MockGetByMovieId(int id)
        {
            ActorRepoMock.Setup(x => x.GetByMovieId(It.IsAny<int>())).Returns(ListOfActors);
        }

    }
}