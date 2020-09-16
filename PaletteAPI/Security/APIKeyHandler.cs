using Palette.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PaletteAPI.Security
{
    public class APIKeyHandler :DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var queryString = request.RequestUri.ParseQueryString();
            var apiKey = queryString["apiKey"];
            UserDAL userDAL = new UserDAL();
            var user = userDAL.GetUserByUserKey(apiKey);
            if (user!=null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Users.Username,"APIKey"));
                HttpContext.Current.User = principal;
            }
           
            return base.SendAsync(request, cancellationToken);
        }
    }
}