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
    public class FollowingsController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/Followings
        public IQueryable<Followings> GetFollowings()
        {
            return db.Followings;
        }

        // GET: api/Followings/5
        [ResponseType(typeof(Followings))]
        public IHttpActionResult GetFollowings(int id)
        {
            Followings followings = db.Followings.Find(id);
            if (followings == null)
            {
                return NotFound();
            }

            return Ok(followings);
        }

        // PUT: api/Followings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFollowings(int id, Followings followings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != followings.FollowingsID)
            {
                return BadRequest();
            }

            db.Entry(followings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowingsExists(id))
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

        // POST: api/Followings
        [ResponseType(typeof(Followings))]
        public IHttpActionResult PostFollowings(Followings followings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Followings.Add(followings);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = followings.FollowingsID }, followings);
        }

        // DELETE: api/Followings/5
        [ResponseType(typeof(Followings))]
        public IHttpActionResult DeleteFollowings(int id)
        {
            Followings followings = db.Followings.Find(id);
            if (followings == null)
            {
                return NotFound();
            }

            db.Followings.Remove(followings);
            db.SaveChanges();

            return Ok(followings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FollowingsExists(int id)
        {
            return db.Followings.Count(e => e.FollowingsID == id) > 0;
        }
    }
}