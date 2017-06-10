using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaImpuls.Startup))]
namespace DeltaImpuls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
