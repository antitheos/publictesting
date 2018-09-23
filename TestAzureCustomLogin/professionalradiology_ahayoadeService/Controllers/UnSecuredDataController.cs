
using System.Net;
using System.Net.Http;
using System.Web.Http;                         
using Microsoft.Azure.Mobile.Server.Config;   


namespace TestAzureCustomLogin.Controllers
{ 
    [MobileAppController]       
    public class UnSecuredDataController : ApiController
    {

        
                                                                                  
       // [HttpPost]
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, new {name ="hello" });
        }

      

    }
}
