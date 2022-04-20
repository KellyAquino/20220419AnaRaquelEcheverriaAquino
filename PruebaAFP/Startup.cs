using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaAFP.Startup))]
namespace PruebaAFP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
