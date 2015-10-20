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
    public class FencesController : ApiController
    {
        private IPacmanRESTContext db = new pacmanAndroidNew_dbEntities();

        public FencesController() { }

        public FencesController(IPacmanRESTContext context)
        {
            db = context;
        }

        // GET: api/Fences
        public IQueryable<Fence> GetFences()
        {
            return db.Fences;
        }

        // GET: api/Fences/5
        [ResponseType(typeof(Fence))]
        public IHttpActionResult GetFence(int id)
        {
            Fence fence = db.Fences.Find(id);
            if (fence == null)
            {
                return NotFound();
            }

            return Ok(fence);
        }

        // PUT: api/Fences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFence(int id, Fence fence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fence.ID)
            {
                return BadRequest();
            }

            //db.Entry(fence).State = EntityState.Modified;
            db.MarkAsModifiedFence(fence);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FenceExists(id))
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

        // POST: api/Fences
        [ResponseType(typeof(Fence))]
        public IHttpActionResult PostFence(Fence fence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fences.Add(fence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fence.ID }, fence);
        }

        // DELETE: api/Fences/5
        [ResponseType(typeof(Fence))]
        public IHttpActionResult DeleteFence(int id)
        {
            Fence fence = db.Fences.Find(id);
            if (fence == null)
            {
                return NotFound();
            }

            db.Fences.Remove(fence);
            db.SaveChanges();

            return Ok(fence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FenceExists(int id)
        {
            return db.Fences.Count(e => e.ID == id) > 0;
        }
    }
}