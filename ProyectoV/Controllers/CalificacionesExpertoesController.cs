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
    public class CalificacionesExpertoesController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/CalificacionesExpertoes
        public IQueryable<CalificacionesExperto> GetCalificacionesExpertos()
        {
            return db.CalificacionesExpertos;
        }

        // GET: api/CalificacionesExpertoes/5
        [ResponseType(typeof(CalificacionesExperto))]
        public async Task<IHttpActionResult> GetCalificacionesExperto(int id)
        {
            CalificacionesExperto calificacionesExperto = await db.CalificacionesExpertos.FindAsync(id);
            if (calificacionesExperto == null)
            {
                return NotFound();
            }

            return Ok(calificacionesExperto);
        }

        // PUT: api/CalificacionesExpertoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalificacionesExperto(int id, CalificacionesExperto calificacionesExperto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificacionesExperto.PeliculaID)
            {
                return BadRequest();
            }

            db.Entry(calificacionesExperto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionesExpertoExists(id))
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

        // POST: api/CalificacionesExpertoes
        [ResponseType(typeof(CalificacionesExperto))]
        public async Task<IHttpActionResult> PostCalificacionesExperto(CalificacionesExperto calificacionesExperto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CalificacionesExpertos.Add(calificacionesExperto);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalificacionesExpertoExists(calificacionesExperto.PeliculaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = calificacionesExperto.PeliculaID }, calificacionesExperto);
        }

        // DELETE: api/CalificacionesExpertoes/5
        [ResponseType(typeof(CalificacionesExperto))]
        public async Task<IHttpActionResult> DeleteCalificacionesExperto(int id)
        {
            CalificacionesExperto calificacionesExperto = await db.CalificacionesExpertos.FindAsync(id);
            if (calificacionesExperto == null)
            {
                return NotFound();
            }

            db.CalificacionesExpertos.Remove(calificacionesExperto);
            await db.SaveChangesAsync();

            return Ok(calificacionesExperto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalificacionesExpertoExists(int id)
        {
            return db.CalificacionesExpertos.Count(e => e.PeliculaID == id) > 0;
        }
    }
}