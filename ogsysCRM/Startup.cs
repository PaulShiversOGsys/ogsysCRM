using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ogsysCRM.Startup))]
namespace ogsysCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
