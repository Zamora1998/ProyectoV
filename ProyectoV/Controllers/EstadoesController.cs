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
    public class EstadoesController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/Estadoes
        public IQueryable<Estado> GetEstadoes()
        {
            return db.Estadoes;
        }

        // GET: api/Estadoes/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> GetEstado(int id)
        {
            Estado estado = await db.Estadoes.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        // PUT: api/Estadoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.EstadoID)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estadoes
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estadoes.Add(estado);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoExists(estado.EstadoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estado.EstadoID }, estado);
        }

        // DELETE: api/Estadoes/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> DeleteEstado(int id)
        {
            Estado estado = await db.Estadoes.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.Estadoes.Remove(estado);
            await db.SaveChangesAsync();

            return Ok(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoExists(int id)
        {
            return db.Estadoes.Count(e => e.EstadoID == id) > 0;
        }
    }
}