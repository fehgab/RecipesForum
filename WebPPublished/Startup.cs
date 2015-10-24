using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPPublished.Startup))]
namespace WebPPublished
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
