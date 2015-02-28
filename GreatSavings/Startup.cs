using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreatSavings.Startup))]
namespace GreatSavings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
