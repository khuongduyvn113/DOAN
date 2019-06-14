using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOAN2.Startup))]
namespace DOAN2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
