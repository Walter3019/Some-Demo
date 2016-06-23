using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMS_PSS_Project.Startup))]
namespace EMS_PSS_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
