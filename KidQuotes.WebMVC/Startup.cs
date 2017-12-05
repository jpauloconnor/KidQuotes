using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidQuotes.WebMVC.Startup))]
namespace KidQuotes.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
