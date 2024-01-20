using IMDB.Models.DB;
using IMDB.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDB.Test.StepFiles
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGetAll();
            ActorMock.MockGet(1);
            ActorMock.MockCreate(new Actor());
            ActorMock.MockUpdate(1, new Actor());
            ActorMock.MockDelete(1);
            ActorMock.MockGetByMovieId(1);


        }
    }
}