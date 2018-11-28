using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LazyLoadSoftDelete.Startup))]
namespace LazyLoadSoftDelete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
