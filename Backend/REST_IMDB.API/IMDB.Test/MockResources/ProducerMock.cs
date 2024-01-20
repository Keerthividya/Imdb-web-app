using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;

namespace IMDB.Test.MockResources
{
    public class ProducerMock
    {
        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        private static readonly IEnumerable<Producer> ListOfProducers = new List<Producer>
        {
                new Producer
                {
                    Id = 1,
                    Name = "Producer 1",
                    Bio = "--",
                    DOB = new DateTime(1990,5,1),
                    Gender="Male",
                    Image=""
                },
                new Producer
                {
                    Id = 2,
                    Name = "Producer 2",
                    Bio = "--",
                    DOB = new DateTime(1980,3,1),
                    Gender="Female",
                    Image=""
                },
        };

        public static void MockGetAll()
        {
            ProducerRepoMock.Setup(x => x.Get()).Returns(ListOfProducers);
        }

        public static void MockGet(int id)
        {
            ProducerRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(ListOfProducers.FirstOrDefault(a => a.Id == id));
        }

        public static void MockUpdate(int id, Producer producer)
        {
            ProducerRepoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Producer>()));

        }

        public static void MockCreate(Producer producer)
        {
            ProducerRepoMock.Setup(x => x.Create(It.IsAny<Producer>())).Returns(3);

        }

        public static void MockDelete(int id)
        {
            ProducerRepoMock.Setup(x => x.Delete(It.IsAny<int>()));

        }
    }
}