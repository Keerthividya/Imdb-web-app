using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;

namespace IMDB.Test.MockResources
{
    public class ReviewMock
    {
        public static readonly Mock<IReviewRepository> ReviewRepoMock = new Mock<IReviewRepository>();

        private static readonly IEnumerable<Review> ListOfReviews = new List<Review>
        {
                new Review
                {
                    Id = 1,
                    Message="Message 1",
                    MovieId=1
                },
                new Review
                {
                    Id = 2,
                    Message = "Message 2",
                    MovieId=2
                },
        };

        public static void MockGetAll()
        {
            ReviewRepoMock.Setup(x => x.Get()).Returns(ListOfReviews);
        }

        public static void MockGet(int id)
        {
            ReviewRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(ListOfReviews.FirstOrDefault(a => a.Id == id));
        }

        public static void MockUpdate(int id, Review review)
        {
            ReviewRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Review>()));

        }

        public static void MockCreate(Review review)
        {
            ReviewRepoMock.Setup(x => x.Create(It.IsAny<Review>())).Returns(3);

        }

        public static void MockDelete(int id)
        {
            ReviewRepoMock.Setup(x => x.Delete(It.IsAny<int>()));

        }
    }
}