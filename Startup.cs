using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JNET.Startup))]
namespace JNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
