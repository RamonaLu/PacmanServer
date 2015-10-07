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
    public class CarerPatientController : ApiController
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();

        // GET: api/CarerPatient
        public IQueryable<Pacman_carer_patient_db> GetPacman_carer_patient_db()
        {
            return db.Pacman_carer_patient_db;
        }

        // GET: api/CarerPatient/5
        [ResponseType(typeof(Pacman_carer_patient_db))]
        public IHttpActionResult GetPacman_carer_patient_db(int id)
        {
            Pacman_carer_patient_db pacman_carer_patient_db = db.Pacman_carer_patient_db.Find(id);
            if (pacman_carer_patient_db == null)
            {
                return NotFound();
            }

            return Ok(pacman_carer_patient_db);
        }

        // PUT: api/CarerPatient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_carer_patient_db(int id, Pacman_carer_patient_db pacman_carer_patient_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_carer_patient_db.ID)
            {
                return BadRequest();
            }

            db.Entry(pacman_carer_patient_db).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_carer_patient_dbExists(id))
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

        // POST: api/CarerPatient
        [ResponseType(typeof(Pacman_carer_patient_db))]
        public IHttpActionResult PostPacman_carer_patient_db(Pacman_carer_patient_db pacman_carer_patient_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_carer_patient_db.Add(pacman_carer_patient_db);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacman_carer_patient_db.ID }, pacman_carer_patient_db);
        }

        // DELETE: api/CarerPatient/5
        [ResponseType(typeof(Pacman_carer_patient_db))]
        public IHttpActionResult DeletePacman_carer_patient_db(int id)
        {
            Pacman_carer_patient_db pacman_carer_patient_db = db.Pacman_carer_patient_db.Find(id);
            if (pacman_carer_patient_db == null)
            {
                return NotFound();
            }

            db.Pacman_carer_patient_db.Remove(pacman_carer_patient_db);
            db.SaveChanges();

            return Ok(pacman_carer_patient_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_carer_patient_dbExists(int id)
        {
            return db.Pacman_carer_patient_db.Count(e => e.ID == id) > 0;
        }
    }
}