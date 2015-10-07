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
    public class PatientController : ApiController
    {
        private IPacmanRESTContext db = new pacmanAndroidNew_dbEntities();

        public PatientController() { }

        public PatientController(IPacmanRESTContext context)
        {
            db = context;
        }

        // GET: api/Patient
        public IQueryable<Pacman_patient_db> GetPacman_patient_db()
        {
            return db.Pacman_patient_dbs;
        }

        // GET: api/Patient/5
        [ResponseType(typeof(Pacman_patient_db))]
        public IHttpActionResult GetPacman_patient_db(int id)
        {
            Pacman_patient_db pacman_patient_db = db.Pacman_patient_dbs.Find(id);
            if (pacman_patient_db == null)
            {
                return NotFound();
            }

            return Ok(pacman_patient_db);
        }

        // PUT: api/Patient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_patient_db(int id, Pacman_patient_db pacman_patient_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_patient_db.ID)
            {
                return BadRequest();
            }

            //db.Entry(pacman_patient_db).State = EntityState.Modified;
            db.MarkAsModified(pacman_patient_db);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_patient_dbExists(id))
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

        // POST: api/Patient
        [ResponseType(typeof(Pacman_patient_db))]
        public IHttpActionResult PostPacman_patient_db(Pacman_patient_db pacman_patient_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_patient_dbs.Add(pacman_patient_db);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacman_patient_db.ID }, pacman_patient_db);
        }

        // DELETE: api/Patient/5
        [ResponseType(typeof(Pacman_patient_db))]
        public IHttpActionResult DeletePacman_patient_db(int id)
        {
            Pacman_patient_db pacman_patient_db = db.Pacman_patient_dbs.Find(id);
            if (pacman_patient_db == null)
            {
                return NotFound();
            }

            db.Pacman_patient_dbs.Remove(pacman_patient_db);
            db.SaveChanges();

            return Ok(pacman_patient_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_patient_dbExists(int id)
        {
            return db.Pacman_patient_dbs.Count(e => e.ID == id) > 0;
        }
    }
}