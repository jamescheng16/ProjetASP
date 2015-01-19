using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iBuy.Startup))]
namespace iBuy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
