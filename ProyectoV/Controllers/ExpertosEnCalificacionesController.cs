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
    public class ExpertosEnCalificacionesController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/ExpertosEnCalificaciones
        public IQueryable<ExpertosEnCalificacione> GetExpertosEnCalificaciones()
        {
            return db.ExpertosEnCalificaciones;
        }

        // GET: api/ExpertosEnCalificaciones/5
        [ResponseType(typeof(ExpertosEnCalificacione))]
        public async Task<IHttpActionResult> GetExpertosEnCalificacione(int id)
        {
            ExpertosEnCalificacione expertosEnCalificacione = await db.ExpertosEnCalificaciones.FindAsync(id);
            if (expertosEnCalificacione == null)
            {
                return NotFound();
            }

            return Ok(expertosEnCalificacione);
        }

        // PUT: api/ExpertosEnCalificaciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExpertosEnCalificacione(int id, ExpertosEnCalificacione expertosEnCalificacione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expertosEnCalificacione.ExpertoID)
            {
                return BadRequest();
            }

            db.Entry(expertosEnCalificacione).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpertosEnCalificacioneExists(id))
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

        // POST: api/ExpertosEnCalificaciones
        [ResponseType(typeof(ExpertosEnCalificacione))]
        public async Task<IHttpActionResult> PostExpertosEnCalificacione(ExpertosEnCalificacione expertosEnCalificacione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExpertosEnCalificaciones.Add(expertosEnCalificacione);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = expertosEnCalificacione.ExpertoID }, expertosEnCalificacione);
        }

        // DELETE: api/ExpertosEnCalificaciones/5
        [ResponseType(typeof(ExpertosEnCalificacione))]
        public async Task<IHttpActionResult> DeleteExpertosEnCalificacione(int id)
        {
            ExpertosEnCalificacione expertosEnCalificacione = await db.ExpertosEnCalificaciones.FindAsync(id);
            if (expertosEnCalificacione == null)
            {
                return NotFound();
            }

            db.ExpertosEnCalificaciones.Remove(expertosEnCalificacione);
            await db.SaveChangesAsync();

            return Ok(expertosEnCalificacione);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpertosEnCalificacioneExists(int id)
        {
            return db.ExpertosEnCalificaciones.Count(e => e.ExpertoID == id) > 0;
        }
    }
}