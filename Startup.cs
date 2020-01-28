using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        //test commit new pc
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
