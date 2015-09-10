using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerRepairShop.Startup))]
namespace ComputerRepairShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
