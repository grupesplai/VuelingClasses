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
using WebApiMvc.Models;

namespace WebApiMvc.Controllers
{
    public class AlumnoController : ApiController
    {
        private ColvalcoFlyWayEntities db = new ColvalcoFlyWayEntities();

        // GET: api/Alumno
        public IQueryable<AlumnoFlyway> GetAlumnoFlyway()
        {
            return db.AlumnoFlyway;
        }

        // GET: api/Alumno/5
        [ResponseType(typeof(AlumnoFlyway))]
        public IHttpActionResult GetAlumnoFlyway(int id)
        {
            AlumnoFlyway alumnoFlyway = db.AlumnoFlyway.Find(id);
            if (alumnoFlyway == null)
            {
                return NotFound();
            }

            return Ok(alumnoFlyway);
        }

        // PUT: api/Alumno/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlumnoFlyway(int id, AlumnoFlyway alumnoFlyway)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumnoFlyway.Id)
            {
                return BadRequest();
            }

            db.Entry(alumnoFlyway).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoFlywayExists(id))
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

        // POST: api/Alumno
        [ResponseType(typeof(AlumnoFlyway))]
        public IHttpActionResult PostAlumnoFlyway(AlumnoFlyway alumnoFlyway)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlumnoFlyway.Add(alumnoFlyway);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alumnoFlyway.Id }, alumnoFlyway);
        }

        // DELETE: api/Alumno/5
        [ResponseType(typeof(AlumnoFlyway))]
        public IHttpActionResult DeleteAlumnoFlyway(int id)
        {
            AlumnoFlyway alumnoFlyway = db.AlumnoFlyway.Find(id);
            if (alumnoFlyway == null)
            {
                return NotFound();
            }

            db.AlumnoFlyway.Remove(alumnoFlyway);
            db.SaveChanges();

            return Ok(alumnoFlyway);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlumnoFlywayExists(int id)
        {
            return db.AlumnoFlyway.Count(e => e.Id == id) > 0;
        }
    }
}