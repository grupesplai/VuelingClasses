﻿using Student.Business.Logic;
using Student.Common.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness studentBl;

        public AlumnoController(ILogger Log, IBusiness business)
        {
            this.Log = Log;
            this.studentBl = business;
        }



        // GET: api/Alumno
        [HttpGet]
        public IHttpActionResult Get()
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.GetAllS());
        }

        // GET: api/Alumno/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(studentBl.GetOneS(id));
        }

        // POST: api/Alumno
        [HttpPost]
        public IHttpActionResult Post(Alumno alumno)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.AddAlumno(alumno));
        }

        // PUT: api/Alumno/5
        [HttpPut]
        public IHttpActionResult Put(int id, Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                        Alumno alumnoFoun = studentBl.GetOneS(id);
                        return Ok(studentBl.UpdateOneS(alumnoFoun));
        }

        // DELETE: api/Alumno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {   
            return Ok(studentBl.DeleteOneS(id));
        }
    }
}
