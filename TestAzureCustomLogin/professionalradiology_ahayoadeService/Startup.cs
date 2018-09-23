using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

[assembly: OwinStartup(typeof(TestAzureCustomLogin.Startup))]

namespace TestAzureCustomLogin
{
    public partial class  Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            ConfigureMobileApp(app);
        }
    }
}
