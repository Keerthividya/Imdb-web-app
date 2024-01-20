using IMDB.Models.DB;
using IMDB.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace IMDB.Test.StepFiles
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGetAll();
            MovieMock.MockGet(1);
            MovieMock.MockCreate(new Movie(), new List<int>(), new List<int>());
            MovieMock.MockUpdate(1, new Movie(), new List<int>(), new List<int>());
            MovieMock.MockDelete(1);
            ActorMock.MockGetByMovieId(1);
            GenreMock.MockGetByMovieId(1);

        }
    }
}