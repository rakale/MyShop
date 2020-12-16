using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Soft.Areas.Identity.IdentityHostingStartup))]
namespace Soft.Areas.Identity {
    public class IdentityHostingStartup : IHostingStartup {
        public void Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}