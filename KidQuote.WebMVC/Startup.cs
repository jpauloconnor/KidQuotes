using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidQuote.WebMVC.Startup))]
namespace KidQuote.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
