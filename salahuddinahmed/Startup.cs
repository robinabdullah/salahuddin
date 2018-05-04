using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(salahuddinahmed.Startup))]
namespace salahuddinahmed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
