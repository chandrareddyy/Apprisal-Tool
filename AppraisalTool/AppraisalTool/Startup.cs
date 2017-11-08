using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppraisalTool.Startup))]
namespace AppraisalTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
