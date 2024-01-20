using IMDB.Models.DB;
using IMDB.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDB.Test.StepFiles
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGetAll();
            GenreMock.MockGet(1);
            GenreMock.MockCreate(new Genre());
            GenreMock.MockUpdate(1, new Genre());
            GenreMock.MockDelete(1);
            GenreMock.MockGetByMovieId(1);

        }
    }
}