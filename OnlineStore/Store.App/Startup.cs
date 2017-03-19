using Microsoft.Owin;
using Owin;
using Store.Data;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Store.App.Startup))]
namespace Store.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            
        }
        
    }
}
