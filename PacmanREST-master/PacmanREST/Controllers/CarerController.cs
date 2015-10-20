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
    public class CarerController : ApiController
    {
        private IPacmanRESTContext db = new pacmanAndroidNew_dbEntities();

        public CarerController() { }

        public CarerController(IPacmanRESTContext context)
        {
            db = context;
        }

        // GET: api/Carer
        public IQueryable<Pacman_carer_db> GetPacman_carer_db()
        {
            return db.Pacman_carer_db;
        }

        // GET: api/Carer/5
        [ResponseType(typeof(Pacman_carer_db))]
        public IHttpActionResult GetPacman_carer_db(int id)
        {
            Pacman_carer_db pacman_carer_db = db.Pacman_carer_db.Find(id);
            if (pacman_carer_db == null)
            {
                return NotFound();
            }

            return Ok(pacman_carer_db);
        }

        // PUT: api/Carer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_carer_db(int id, Pacman_carer_db pacman_carer_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_carer_db.ID)
            {
                return BadRequest();
            }

            //db.Entry(pacman_carer_db).State = EntityState.Modified;
            db.MarkAsModifiedPacman_carer_db(pacman_carer_db);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_carer_dbExists(id))
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

        // POST: api/Carer
        [ResponseType(typeof(Pacman_carer_db))]
        public IHttpActionResult PostPacman_carer_db(Pacman_carer_db pacman_carer_db)
        {
            //pacman_carer_db.ID = 0;
            //pacman_carer_db.device_id = "j";
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_carer_db.Add(pacman_carer_db);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacman_carer_db.ID }, pacman_carer_db);
        }

        // DELETE: api/Carer/5
        [ResponseType(typeof(Pacman_carer_db))]
        public IHttpActionResult DeletePacman_carer_db(int id)
        {
            Pacman_carer_db pacman_carer_db = db.Pacman_carer_db.Find(id);
            if (pacman_carer_db == null)
            {
                return NotFound();
            }

            db.Pacman_carer_db.Remove(pacman_carer_db);
            db.SaveChanges();

            return Ok(pacman_carer_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_carer_dbExists(int id)
        {
            return db.Pacman_carer_db.Count(e => e.ID == id) > 0;
        }
    }
}