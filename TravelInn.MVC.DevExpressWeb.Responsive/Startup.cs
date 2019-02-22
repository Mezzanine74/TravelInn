using Microsoft.Owin;
using Owin;
using TravelInn.MVC.DevExpressWeb.Responsive;

[assembly: OwinStartup(typeof(Startup))]

// Files related to ASP.NET Identity duplicate the Microsoft ASP.NET Identity file structure and contain initial Microsoft comments.

namespace TravelInn.MVC.DevExpressWeb.Responsive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}