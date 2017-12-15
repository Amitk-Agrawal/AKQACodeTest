using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AKQA.CodeTest.Web.Startup))]
namespace AKQA.CodeTest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
