using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab1MLS.Startup))]
namespace Lab1MLS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
