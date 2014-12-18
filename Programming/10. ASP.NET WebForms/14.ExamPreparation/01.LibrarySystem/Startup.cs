using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.LibrarySystem.Startup))]
namespace _01.LibrarySystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
