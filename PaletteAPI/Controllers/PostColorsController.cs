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
    public class PostColorsController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/PostColors
        public IQueryable<PostColors> GetPostColors()
        {
            return db.PostColors;
        }

        // GET: api/PostColors/5
        [ResponseType(typeof(PostColors))]
        public IHttpActionResult GetPostColors(int id)
        {
            PostColors postColors = db.PostColors.Find(id);
            if (postColors == null)
            {
                return NotFound();
            }

            return Ok(postColors);
        }

        // PUT: api/PostColors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostColors(int id, PostColors postColors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postColors.PostColorID)
            {
                return BadRequest();
            }

            db.Entry(postColors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostColorsExists(id))
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

        // POST: api/PostColors
        [ResponseType(typeof(PostColors))]
        public IHttpActionResult PostPostColors(PostColors postColors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostColors.Add(postColors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postColors.PostColorID }, postColors);
        }

        // DELETE: api/PostColors/5
        [ResponseType(typeof(PostColors))]
        public IHttpActionResult DeletePostColors(int id)
        {
            PostColors postColors = db.PostColors.Find(id);
            if (postColors == null)
            {
                return NotFound();
            }

            db.PostColors.Remove(postColors);
            db.SaveChanges();

            return Ok(postColors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostColorsExists(int id)
        {
            return db.PostColors.Count(e => e.PostColorID == id) > 0;
        }
    }
}