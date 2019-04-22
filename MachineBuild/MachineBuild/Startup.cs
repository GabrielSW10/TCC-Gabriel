using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MachineBuild.Startup))]
namespace MachineBuild
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
