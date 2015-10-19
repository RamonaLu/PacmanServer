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
using PacmanREST.Logic;

namespace PacmanREST.Controllers
{
    public class LocationController : ApiController
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();

        // GET: api/Location
        public IQueryable<Pacman_location_db> GetPacman_location_db()
        {
            return db.Pacman_location_db;
        }

        // GET: api/Location/5
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult GetPacman_location_db(int id)
        {
            Pacman_location_db pacman_location_db = db.Pacman_location_db.Find(id);
            if (pacman_location_db == null)
            {
                //return NotFound();
            }
            //checkFence cf = new checkFence();
            //cf.alarm();
            //return cf.apiResult + "blah";
            return Ok(pacman_location_db);
        }

        [Route("api/Location/LastPatientLocation/{id}")]
        [HttpGet]
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult GetLastPatientLocation(int id)
        {
            var locs = (from l in db.Pacman_location_db
                        where (l.id_patient == id)
                        orderby l.ID descending
                        select l).First();
            return Ok(locs);
        }

        [Route("api/Location/testAlarm/{id}")]
        [HttpGet]
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult GettestAlarm(int id)
        {
            checkFence cf = new checkFence();
            var location = (from l in db.Pacman_location_db
                        where (l.ID == id)
                        orderby l.ID descending
                        select l).First();

            if (location != null)
            {
                
                cf.patientx = 1;
                cf.patienty = 2;
                //cf.patientx = location.coordinates_x;
                //cf.patienty = location.coordinates_y;
                var fence = (from f in db.Pacman_fence_db
                             where (f.id_patient == location.id_patient)
                             orderby f.ID descending
                             select f).FirstOrDefault();
                cf.fencex = Convert.ToDecimal(fence.Latitude);
                cf.fencey = Convert.ToDecimal(fence.Longitude);
                cf.radius = fence.radius;


                var client = (from c in db.Pacman_carer_db
                              where c.ID == location.id_carer
                              select c).FirstOrDefault();
                cf.careDeviceId = client.device_id;

                var pncl = (from c in db.Pacman_patient_db
                            where c.ID == location.id_patient
                            select c).FirstOrDefault();
                cf.patientName = pncl.name;

                cf.distanceCheck();
                return Ok(cf.apiResult);
            }
            else
            {
                return Ok("nullled?");
            }
            
        }

        // PUT: api/Location/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_location_db(int id, Pacman_location_db pacman_location_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_location_db.ID)
            {
                return BadRequest();
            }

            db.Entry(pacman_location_db).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_location_dbExists(id))
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

        // POST: api/Location
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult PostPacman_location_db(Pacman_location_db location)
        {
            if (location != null)
            {
                location.ID = null;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_location_db.Add(location);
            db.SaveChanges();
            
            location = db.Pacman_location_db.Find(location.ID);
        
            if (location != null)
            {
                checkFence cf = new checkFence();
                cf.patientx = location.coordinates_x;
                cf.patienty = location.coordinates_y;
                var fence = (from f in db.Pacman_fence_db
                             where (f.id_patient == location.id_patient)
                             orderby f.ID descending
                             select f).FirstOrDefault();
                if (fence != null)
                {
                    cf.fencex = Convert.ToDecimal(fence.Latitude);
                    cf.fencey = Convert.ToDecimal(fence.Longitude);
                    cf.radius = fence.radius;


                    var client = (from c in db.Pacman_carer_db
                                  where c.ID == location.id_carer
                                  select c).FirstOrDefault();
                    cf.careDeviceId = client.device_id;

                    var pncl = (from c in db.Pacman_patient_db
                                where c.ID == location.id_patient
                                select c).FirstOrDefault();
                    cf.patientName = pncl.name;

                    cf.distanceCheck();
                }
                
                try
                {
                    var fences = from patient in db.Pacman_patient_db
                                 join f in db.Fences on patient.ID equals f.ID
                                 where patient.ID == location.id_patient
                                 select f;

                    foreach (var f in fences)
                    {
                        var points = from fencePoint in db.FencePoints
                                     where fencePoint.FenceID == f.ID
                                     orderby fencePoint.ID
                                     select fencePoint;

                        var sides = Tuplise(points.ToList());

                        if (!CheckPolygonFence.CheckPointInside(sides, location))
                        {
                            cf.alarm();
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }
            
                        

            return CreatedAtRoute("DefaultApi", new { id = location.ID }, location);
        }

        private IEnumerable<Tuple<FencePoint, FencePoint>> Tuplise(IList<FencePoint> points)
        {
            for (int i = 0; i < points.Count(); i++)
            {
                Tuple<FencePoint, FencePoint> side = new Tuple<FencePoint, FencePoint>(points[i], points[(i+1) % points.Count()]);
                yield return side;
            }
        }

// DELETE: api/Location/5
[ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult DeletePacman_location_db(int id)
        {
            Pacman_location_db pacman_location_db = db.Pacman_location_db.Find(id);
            if (pacman_location_db == null)
            {
                return NotFound();
            }

            db.Pacman_location_db.Remove(pacman_location_db);
            db.SaveChanges();

            return Ok(pacman_location_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_location_dbExists(int id)
        {
            return db.Pacman_location_db.Count(e => e.ID == id) > 0;
        }
    }
}