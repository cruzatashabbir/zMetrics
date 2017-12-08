using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.web.Startup))]
namespace Project.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
