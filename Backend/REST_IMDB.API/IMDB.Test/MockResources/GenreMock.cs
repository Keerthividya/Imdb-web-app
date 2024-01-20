using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;

namespace IMDB.Test.MockResources
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        private static readonly IEnumerable<Genre> ListOfGenres = new List<Genre>
        {
               new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Horror"
                },
        };

        public static void MockGetAll()
        {
            GenreRepoMock.Setup(x => x.Get()).Returns(ListOfGenres);
        }

        public static void MockGet(int id)
        {
            GenreRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(ListOfGenres.FirstOrDefault(a => a.Id == id));
        }

        public static void MockUpdate(int id, Genre genre)
        {
            GenreRepoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Genre>()));

        }

        public static void MockCreate(Genre genre)
        {
            GenreRepoMock.Setup(x => x.Create(It.IsAny<Genre>())).Returns(3);

        }

        public static void MockDelete(int id)
        {
            GenreRepoMock.Setup(x => x.Delete(It.IsAny<int>()));

        }

        public static void MockGetByMovieId(int id)
        {
            GenreRepoMock.Setup(x => x.GetByMovieId(It.IsAny<int>())).Returns(ListOfGenres);
        }
    }
}