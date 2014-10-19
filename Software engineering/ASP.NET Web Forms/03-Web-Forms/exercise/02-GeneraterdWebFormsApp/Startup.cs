using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02_GeneraterdWebFormsApp.Startup))]
namespace _02_GeneraterdWebFormsApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
