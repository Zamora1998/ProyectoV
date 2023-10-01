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
    public class PeliculasController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/Peliculas
        public IQueryable<Pelicula> GetPeliculas()
        {
            return db.Peliculas;
        }

        // GET: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public async Task<IHttpActionResult> GetPelicula(int id)
        {
            Pelicula pelicula = await db.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // PUT: api/Peliculas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPelicula(int id, Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pelicula.PeliculaID)
            {
                return BadRequest();
            }

            db.Entry(pelicula).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
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

        // POST: api/Peliculas
        [ResponseType(typeof(Pelicula))]
        public async Task<IHttpActionResult> PostPelicula(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Peliculas.Add(pelicula);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pelicula.PeliculaID }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [ResponseType(typeof(Pelicula))]
        public async Task<IHttpActionResult> DeletePelicula(int id)
        {
            Pelicula pelicula = await db.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            db.Peliculas.Remove(pelicula);
            await db.SaveChangesAsync();

            return Ok(pelicula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeliculaExists(int id)
        {
            return db.Peliculas.Count(e => e.PeliculaID == id) > 0;
        }
    }
}