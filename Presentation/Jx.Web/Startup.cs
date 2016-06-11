using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jx.Web.Startup))]
namespace Jx.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
