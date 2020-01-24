using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplikacjeInternetoweProject.Startup))]
namespace AplikacjeInternetoweProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
