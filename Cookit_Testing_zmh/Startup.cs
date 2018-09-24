using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cookit_Testing_zmh.Startup))]
namespace Cookit_Testing_zmh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
