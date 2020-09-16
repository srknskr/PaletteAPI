using Palette.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PaletteAPI.Security
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var username = HttpContext.Current.User.Identity.Name;
            UserDAL userDAL = new UserDAL();
            var user = userDAL.GetUserByUsername(username);
            var apirole = userDAL.GetAPIKeysByUserID(user.Username);
            if (user!=null && actionRoles.Contains(apirole.APIRole))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}