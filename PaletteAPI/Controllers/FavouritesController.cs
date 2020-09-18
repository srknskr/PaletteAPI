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
    public class FavouritesController : ApiController
    {
        private PaletteEntities db = new PaletteEntities();

        // GET: api/Favourites
        public IQueryable<Favourites> GetFavourites()
        {
            return db.Favourites;
        }

        // GET: api/Favourites/5
        [ResponseType(typeof(Favourites))]
        public IHttpActionResult GetFavourites(int id)
        {
            Favourites favourites = db.Favourites.Find(id);
            if (favourites == null)
            {
                return NotFound();
            }

            return Ok(favourites);
        }

        // PUT: api/Favourites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavourites(int id, Favourites favourites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favourites.FavouriteID)
            {
                return BadRequest();
            }

            db.Entry(favourites).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouritesExists(id))
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

        // POST: api/Favourites
        [ResponseType(typeof(Favourites))]
        public IHttpActionResult PostFavourites(Favourites favourites)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favourites.Add(favourites);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = favourites.FavouriteID }, favourites);
        }

        // DELETE: api/Favourites/5
        [ResponseType(typeof(Favourites))]
        public IHttpActionResult DeleteFavourites(int id)
        {
            Favourites favourites = db.Favourites.Find(id);
            if (favourites == null)
            {
                return NotFound();
            }

            db.Favourites.Remove(favourites);
            db.SaveChanges();

            return Ok(favourites);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavouritesExists(int id)
        {
            return db.Favourites.Count(e => e.FavouriteID == id) > 0;
        }
    }
}