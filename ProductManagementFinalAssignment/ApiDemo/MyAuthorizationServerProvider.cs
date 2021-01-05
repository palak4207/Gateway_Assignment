using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiDemo
{
    //Class For Authentication
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserCheck _repo = new UserCheck())
            {
                //check user is authrnticate or not
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                     context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.username));
                identity.AddClaim(new Claim("Email", user.username));
                context.Validated(identity);
            }
        }
    }
}