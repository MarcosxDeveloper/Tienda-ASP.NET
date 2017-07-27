using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaEnLinea.Startup))]
namespace TiendaEnLinea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
