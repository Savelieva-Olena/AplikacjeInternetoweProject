using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Model;
using Model.Identity;
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
