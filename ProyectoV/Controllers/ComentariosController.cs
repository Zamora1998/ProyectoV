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
    public class ComentariosController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/Comentarios
        public IQueryable<Comentario> GetComentarios()
        {
            return db.Comentarios;
        }

        // GET: api/Comentarios/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> GetComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // PUT: api/Comentarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.ComentarioID)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentarios
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentarios.Add(comentario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comentario.ComentarioID }, comentario);
        }

        // DELETE: api/Comentarios/5
        [ResponseType(typeof(Comentario))]
        public async Task<IHttpActionResult> DeleteComentario(int id)
        {
            Comentario comentario = await db.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentarios.Remove(comentario);
            await db.SaveChangesAsync();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentarios.Count(e => e.ComentarioID == id) > 0;
        }
    }
}