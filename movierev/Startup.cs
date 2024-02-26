using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movierev.Startup))]
namespace movierev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
