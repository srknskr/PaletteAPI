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
    public class PostTagsController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/PostTags
        public IQueryable<PostTags> GetPostTags()
        {
            return db.PostTags;
        }

        // GET: api/PostTags/5
        [ResponseType(typeof(PostTags))]
        public IHttpActionResult GetPostTags(int id)
        {
            PostTags postTags = db.PostTags.Find(id);
            if (postTags == null)
            {
                return NotFound();
            }

            return Ok(postTags);
        }

        // PUT: api/PostTags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostTags(int id, PostTags postTags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postTags.PostTagID)
            {
                return BadRequest();
            }

            db.Entry(postTags).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagsExists(id))
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

        // POST: api/PostTags
        [ResponseType(typeof(PostTags))]
        public IHttpActionResult PostPostTags(PostTags postTags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostTags.Add(postTags);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postTags.PostTagID }, postTags);
        }

        // DELETE: api/PostTags/5
        [ResponseType(typeof(PostTags))]
        public IHttpActionResult DeletePostTags(int id)
        {
            PostTags postTags = db.PostTags.Find(id);
            if (postTags == null)
            {
                return NotFound();
            }

            db.PostTags.Remove(postTags);
            db.SaveChanges();

            return Ok(postTags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostTagsExists(int id)
        {
            return db.PostTags.Count(e => e.PostTagID == id) > 0;
        }
    }
}