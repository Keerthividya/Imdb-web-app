using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using IMDB.Models.DB;
using IMDB.Repository.Interfaces;

namespace IMDB.Test.MockResources
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        private static readonly IEnumerable<Movie> ListOfMovies = new List<Movie>
        {         
                new Movie
                {
                    Id = 1,
                    Name = "Movie 1",
                    YearOfRelease = 2020,
                    Plot="About the movie",
                    Language="Tamil",
                    Producer="Producer 1",
                    CoverImage="Image"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Movie 2",
                    YearOfRelease = 2021,
                    Plot="About the movie",
                    Language="Tamil",
                    Producer="Producer 2",
                    CoverImage="Image"
                },     
        };

        public static void MockGetAll()
        {
            MovieRepoMock.Setup(x => x.Get()).Returns(ListOfMovies);
        }

        public static void MockGet(int id)
        {
            MovieRepoMock.Setup(x => x.Get(It.IsAny<int>())).Returns(ListOfMovies.FirstOrDefault(a => a.Id == id));
        }

        public static void MockUpdate(int id, Movie movie,List<int>actors,List<int>genre)
        {
            MovieRepoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>()));

        }

        public static void MockCreate(Movie movie, List<int> actors, List<int> genre)
        {
            MovieRepoMock.Setup(x => x.Create(It.IsAny<Movie>(), It.IsAny<List<int>>(), It.IsAny<List<int>>())).Returns(3);

        }

        public static void MockDelete(int id)
        {
            MovieRepoMock.Setup(x => x.Delete(It.IsAny<int>()));

        }

        
    }
}