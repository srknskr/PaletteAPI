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
    public class APIKeysController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/APIKeys
        public IQueryable<APIKeys> GetAPIKeys()
        {
            return db.APIKeys;
        }

        // GET: api/APIKeys/5
        [ResponseType(typeof(APIKeys))]
        public IHttpActionResult GetAPIKeys(int id)
        {
            APIKeys aPIKeys = db.APIKeys.Find(id);
            if (aPIKeys == null)
            {
                return NotFound();
            }

            return Ok(aPIKeys);
        }

        // PUT: api/APIKeys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAPIKeys(int id, APIKeys aPIKeys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPIKeys.APIKeyID)
            {
                return BadRequest();
            }

            db.Entry(aPIKeys).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIKeysExists(id))
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

        // POST: api/APIKeys
        [ResponseType(typeof(APIKeys))]
        public IHttpActionResult PostAPIKeys(APIKeys aPIKeys)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APIKeys.Add(aPIKeys);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aPIKeys.APIKeyID }, aPIKeys);
        }

        // DELETE: api/APIKeys/5
        [ResponseType(typeof(APIKeys))]
        public IHttpActionResult DeleteAPIKeys(int id)
        {
            APIKeys aPIKeys = db.APIKeys.Find(id);
            if (aPIKeys == null)
            {
                return NotFound();
            }

            db.APIKeys.Remove(aPIKeys);
            db.SaveChanges();

            return Ok(aPIKeys);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APIKeysExists(int id)
        {
            return db.APIKeys.Count(e => e.APIKeyID == id) > 0;
        }
    }
}