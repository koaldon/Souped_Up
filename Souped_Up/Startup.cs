using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Souped_Up.Startup))]
namespace Souped_Up
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
