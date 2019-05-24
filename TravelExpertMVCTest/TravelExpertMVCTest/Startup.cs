using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelExpertMVCTest.Startup))]
namespace TravelExpertMVCTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
