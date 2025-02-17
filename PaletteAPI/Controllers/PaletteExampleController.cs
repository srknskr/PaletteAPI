﻿using Palette.DAL;
using PaletteAPI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PaletteAPI.Controllers
{
    
    public class PaletteExampleController : ApiController
    {
        UsersDAL userDAL = new UsersDAL();

        [ResponseType(typeof(IEnumerable<Users>))]
        //[Authorize]

        public IHttpActionResult Get()
        {
            var user= userDAL.GetAllUsers();
            return Ok(user);
            //return Request.CreateResponse(HttpStatusCode.OK,user);
        }

        [ResponseType(typeof(Users))]
      //  [Authorize]
       // [APIAuthorize(Roles = "admin     ")]
        public IHttpActionResult Get(int id)
        {
            var user = userDAL.GetUsersById(id);
            if (user==null)
            {
                return NotFound();
                //return Request.CreateResponse(HttpStatusCode.NotFound,"There is no record that has this id.");
            }
            return Ok(user);
            //return Request.CreateResponse(HttpStatusCode.OK, user);
           
        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult Post(Users user)
        {
            if (ModelState.IsValid)
            {
                var createdUser= userDAL.CreateUser(user);
                return CreatedAtRoute("DefaultApi", new { id = createdUser.UserID }, createdUser);
                //return Request.CreateResponse(HttpStatusCode.Created, creadtedUser);
            }
            else
            {
                return BadRequest(ModelState);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            } 
        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult Put (int id,Users user)
        {
            if (userDAL.IsThereAnyUser(id)==false)
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound,"There is no record");
            }
            else if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
            else
            {
                return Ok(userDAL.UpdateUser(id,user));
                //return Request.CreateResponse(HttpStatusCode.OK, paletteDAL.UpdateUser(id, user));
            }
            
        }
        public IHttpActionResult Delete(int id)
        {
            if (userDAL.IsThereAnyUser(id)==false)
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Not found record");
            }
            else
            {
                userDAL.DeleteUser(id);
                return Ok();
                //return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}
