using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tic_tac_toe.Startup))]
namespace Tic_tac_toe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
