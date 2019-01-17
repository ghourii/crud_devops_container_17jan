using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crud_devops_container_17jan.Startup))]
namespace crud_devops_container_17jan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
