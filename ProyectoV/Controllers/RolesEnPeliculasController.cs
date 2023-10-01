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
    public class RolesEnPeliculasController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/RolesEnPeliculas
        public IQueryable<RolesEnPelicula> GetRolesEnPeliculas()
        {
            return db.RolesEnPeliculas;
        }

        // GET: api/RolesEnPeliculas/5
        [ResponseType(typeof(RolesEnPelicula))]
        public async Task<IHttpActionResult> GetRolesEnPelicula(int id)
        {
            RolesEnPelicula rolesEnPelicula = await db.RolesEnPeliculas.FindAsync(id);
            if (rolesEnPelicula == null)
            {
                return NotFound();
            }

            return Ok(rolesEnPelicula);
        }

        // PUT: api/RolesEnPeliculas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRolesEnPelicula(int id, RolesEnPelicula rolesEnPelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolesEnPelicula.RolEnPeliculaID)
            {
                return BadRequest();
            }

            db.Entry(rolesEnPelicula).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesEnPeliculaExists(id))
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

        // POST: api/RolesEnPeliculas
        [ResponseType(typeof(RolesEnPelicula))]
        public async Task<IHttpActionResult> PostRolesEnPelicula(RolesEnPelicula rolesEnPelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RolesEnPeliculas.Add(rolesEnPelicula);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rolesEnPelicula.RolEnPeliculaID }, rolesEnPelicula);
        }

        // DELETE: api/RolesEnPeliculas/5
        [ResponseType(typeof(RolesEnPelicula))]
        public async Task<IHttpActionResult> DeleteRolesEnPelicula(int id)
        {
            RolesEnPelicula rolesEnPelicula = await db.RolesEnPeliculas.FindAsync(id);
            if (rolesEnPelicula == null)
            {
                return NotFound();
            }

            db.RolesEnPeliculas.Remove(rolesEnPelicula);
            await db.SaveChangesAsync();

            return Ok(rolesEnPelicula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolesEnPeliculaExists(int id)
        {
            return db.RolesEnPeliculas.Count(e => e.RolEnPeliculaID == id) > 0;
        }
    }
}