using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Palette.DAL;

namespace PaletteAPI.Controllers
{
    public class UserProfilesController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/UserProfiles
        public IQueryable<UserProfile> GetUserProfile()
        {
            return db.UserProfile;
        }

        // GET: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfile(int id)
        {
            UserProfile userProfile = db.UserProfile.Find(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // PUT: api/UserProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfile(int id, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.UserProfileID)
            {
                return BadRequest();
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserProfiles
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfile(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfile.Add(userProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userProfile.UserProfileID }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult DeleteUserProfile(int id)
        {
            UserProfile userProfile = db.UserProfile.Find(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            db.UserProfile.Remove(userProfile);
            db.SaveChanges();

            return Ok(userProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileExists(int id)
        {
            return db.UserProfile.Count(e => e.UserProfileID == id) > 0;
        }
    }
}