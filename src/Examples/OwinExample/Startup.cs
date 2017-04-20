using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OwinExample.Startup))]
namespace OwinExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureLogging(app);
        }
    }
}