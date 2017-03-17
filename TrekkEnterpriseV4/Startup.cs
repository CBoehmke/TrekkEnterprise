using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrekkEnterpriseV4.Startup))]
namespace TrekkEnterpriseV4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
