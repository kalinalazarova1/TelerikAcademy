using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsChat.Startup))]
namespace WebFormsChat
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
