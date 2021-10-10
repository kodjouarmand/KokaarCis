using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(KokaarCis.Areas.Identity.IdentityHostingStartup))]
namespace KokaarCis.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}