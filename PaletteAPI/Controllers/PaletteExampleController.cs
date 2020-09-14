using Palette.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaletteAPI.Controllers
{
    
    public class PaletteExampleController : ApiController
    {
        PaletteDAL paletteDAL = new PaletteDAL();

        public HttpResponseMessage Get()
        {
            var user= paletteDAL.GetAllUsers();
            return Request.CreateResponse(HttpStatusCode.OK,user);
        }
        public HttpResponseMessage Get(int id)
        {
            var user = paletteDAL.GetUsersById(id);
            if (user==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"There is no record that has this id.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
           
        }
        public HttpResponseMessage Post(Users user)
        {
            if (ModelState.IsValid)
            {
                var creadtedUser= paletteDAL.CreateUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, creadtedUser);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            } 
        }
        public HttpResponseMessage Put (int id,Users user)
        {
            if (paletteDAL.IsThereAnyUser(id)==false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"There is no record");
            }
            else if (ModelState.IsValid==false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, paletteDAL.UpdateUser(id, user));
            }
            
        }
        public HttpResponseMessage Delete(int id)
        {
            if (paletteDAL.IsThereAnyUser(id)==false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Not found record");
            }
            else
            {
                paletteDAL.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}
