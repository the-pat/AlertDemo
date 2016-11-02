using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlertDemo.Startup))]
namespace AlertDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
