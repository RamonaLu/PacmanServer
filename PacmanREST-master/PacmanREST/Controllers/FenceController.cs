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
using PacmanREST.Models;

namespace PacmanREST.Controllers
{
    public class FenceController : ApiController
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();

        // GET: api/Fence
        public IQueryable<Pacman_fence_db> GetPacman_fence_db()
        {
            return db.Pacman_fence_db;
        }

        // GET: api/Fence/5
        [ResponseType(typeof(Pacman_fence_db))]
        public IHttpActionResult GetPacman_fence_db(int id)
        {
            Pacman_fence_db pacman_fence_db = db.Pacman_fence_db.Find(id);
            if (pacman_fence_db == null)
            {
                return NotFound();
            }

            return Ok(pacman_fence_db);
        }

        // PUT: api/Fence/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_fence_db(int id, Pacman_fence_db pacman_fence_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_fence_db.ID)
            {
                return BadRequest();
            }

            db.Entry(pacman_fence_db).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_fence_dbExists(id))
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

        // POST: api/Fence
        [ResponseType(typeof(Pacman_fence_db))]
        public IHttpActionResult PostPacman_fence_db(Pacman_fence_db pacman_fence_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_fence_db.Add(pacman_fence_db);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacman_fence_db.ID }, pacman_fence_db);
        }

        // DELETE: api/Fence/5
        [ResponseType(typeof(Pacman_fence_db))]
        public IHttpActionResult DeletePacman_fence_db(int id)
        {
            Pacman_fence_db pacman_fence_db = db.Pacman_fence_db.Find(id);
            if (pacman_fence_db == null)
            {
                return NotFound();
            }

            db.Pacman_fence_db.Remove(pacman_fence_db);
            db.SaveChanges();

            return Ok(pacman_fence_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_fence_dbExists(int id)
        {
            return db.Pacman_fence_db.Count(e => e.ID == id) > 0;
        }
    }
}