using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExploreEntity.Startup))]
namespace ExploreEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
