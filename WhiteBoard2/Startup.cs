using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhiteBoard2.Startup))]
namespace WhiteBoard2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
