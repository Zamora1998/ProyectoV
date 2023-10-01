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
    public class ActoresStaffsController : ApiController
    {
        private PeliculasProgra11Entities db = new PeliculasProgra11Entities();

        // GET: api/ActoresStaffs
        public IQueryable<ActoresStaff> GetActoresStaffs()
        {
            return db.ActoresStaffs;
        }

        // GET: api/ActoresStaffs/5
        [ResponseType(typeof(ActoresStaff))]
        public async Task<IHttpActionResult> GetActoresStaff(int id)
        {
            ActoresStaff actoresStaff = await db.ActoresStaffs.FindAsync(id);
            if (actoresStaff == null)
            {
                return NotFound();
            }

            return Ok(actoresStaff);
        }

        // PUT: api/ActoresStaffs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActoresStaff(int id, ActoresStaff actoresStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actoresStaff.ActorStaffID)
            {
                return BadRequest();
            }

            db.Entry(actoresStaff).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActoresStaffExists(id))
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

        // POST: api/ActoresStaffs
        [ResponseType(typeof(ActoresStaff))]
        public async Task<IHttpActionResult> PostActoresStaff(ActoresStaff actoresStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActoresStaffs.Add(actoresStaff);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = actoresStaff.ActorStaffID }, actoresStaff);
        }

        // DELETE: api/ActoresStaffs/5
        [ResponseType(typeof(ActoresStaff))]
        public async Task<IHttpActionResult> DeleteActoresStaff(int id)
        {
            ActoresStaff actoresStaff = await db.ActoresStaffs.FindAsync(id);
            if (actoresStaff == null)
            {
                return NotFound();
            }

            db.ActoresStaffs.Remove(actoresStaff);
            await db.SaveChangesAsync();

            return Ok(actoresStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActoresStaffExists(int id)
        {
            return db.ActoresStaffs.Count(e => e.ActorStaffID == id) > 0;
        }
    }
}