using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryTracking.Startup))]
namespace InventoryTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
