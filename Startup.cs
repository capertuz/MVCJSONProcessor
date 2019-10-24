using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APIProcessor.Startup))]
namespace APIProcessor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
