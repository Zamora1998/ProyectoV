using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DataPeliculas;

namespace ProyectoV.Controllers
{
    public class PostersController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/Posters
        public IQueryable<Poster> GetPosters()
        {
            return db.Posters;
        }

        // GET: api/Posters/5
        [ResponseType(typeof(Poster))]
        public async Task<IHttpActionResult> GetPoster(int id)
        {
            Poster poster = await db.Posters.FindAsync(id);
            if (poster == null)
            {
                return NotFound();
            }

            return Ok(poster);
        }

        // PUT: api/Posters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoster(int id, Poster poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poster.PosterID)
            {
                return BadRequest();
            }

            db.Entry(poster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterExists(id))
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

        // POST: api/Posters
        [ResponseType(typeof(Poster))]
        public async Task<IHttpActionResult> PostPoster(Poster poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posters.Add(poster);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PosterExists(poster.PosterID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = poster.PosterID }, poster);
        }

        // DELETE: api/Posters/5
        [ResponseType(typeof(Poster))]
        public async Task<IHttpActionResult> DeletePoster(int id)
        {
            Poster poster = await db.Posters.FindAsync(id);
            if (poster == null)
            {
                return NotFound();
            }

            db.Posters.Remove(poster);
            await db.SaveChangesAsync();

            return Ok(poster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosterExists(int id)
        {
            return db.Posters.Count(e => e.PosterID == id) > 0;
        }
    }
}