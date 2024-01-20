using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;


namespace IMDB.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
    {     
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseEnvironment("Testing")
                    .UseSetting("https_port", "443")
                    .UseStartup<TestStartup>();
            });
        }
    }

}
