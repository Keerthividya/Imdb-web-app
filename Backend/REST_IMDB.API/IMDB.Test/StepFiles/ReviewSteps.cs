using IMDB.Models.DB;
using IMDB.Test.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDB.Test.StepFiles
{
    [Scope(Feature = "Review Resource")]
    [Binding]
    public class ReviewSteps : BaseSteps
    {
        public ReviewSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ReviewMock.ReviewRepoMock.Object);
                    services.AddScoped(_ => MovieMock.MovieRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ReviewMock.MockGetAll();
            ReviewMock.MockGet(1);
            ReviewMock.MockCreate(new Review());
            ReviewMock.MockUpdate(1, new Review());
            ReviewMock.MockDelete(1);

        }
    }
}