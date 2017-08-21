using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Essi.Startup))]
namespace Essi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
