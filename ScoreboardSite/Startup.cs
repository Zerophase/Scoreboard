using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScoreboardSite.Startup))]
namespace ScoreboardSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
