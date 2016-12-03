using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DendrochronologyReferenceBook.Startup))]
namespace DendrochronologyReferenceBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
