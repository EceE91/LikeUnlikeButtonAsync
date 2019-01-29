using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CleverbitLikeUnlikePagesApp.Startup))]
namespace CleverbitLikeUnlikePagesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
