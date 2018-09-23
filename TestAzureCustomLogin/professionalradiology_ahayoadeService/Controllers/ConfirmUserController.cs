using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;                        
using System.Security.Claims;                     
using Microsoft.Azure.Mobile.Server.Config;
using System.IdentityModel.Tokens;
using Microsoft.Azure.Mobile.Server.Login;


namespace TestAzureCustomLogin.Controllers
{ 
  
    [Route(".auth/login/custom")]
    public class ConfirmUserController : ApiController
    {
        
                                                                                  
        [HttpPost]
        public HttpResponseMessage Post(string username, string password)
        {
             

            JwtSecurityToken token = this.GetAuthenticationTokenForUser(username);

            return this.Request.CreateResponse(HttpStatusCode.OK, new
            {
                Token = token.RawData,
                Username = username ,       
                expires = DateTime.UtcNow.AddHours(tokenLifetimeExceptionHours - 1)
            });
        }

        private JwtSecurityToken GetAuthenticationTokenForUser(string username)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),    
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, username),
            };
                                         

            var thisUrl = string.Format("https://{0}/", Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME"));

            var signingKey = Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");
            var audience = thisUrl; // audience must match the url of the site
            var issuer = thisUrl; // audience must match the url of the site

    JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
        claims,
        signingKey,
        audience,
        issuer,
        TimeSpan.FromHours(tokenLifetimeExceptionHours)
        );

            return token;
        }
        static private int tokenLifetimeExceptionHours = 12;


    }
}
