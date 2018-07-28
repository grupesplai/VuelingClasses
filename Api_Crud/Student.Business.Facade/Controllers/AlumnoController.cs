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
        public IHttpActionResult Get()
        {
            return Ok(studentBl.GetAllS());
        }

        // GET: api/Alumno/5
        public IHttpActionResult Get(int id)
        {
            return Ok(studentBl.GetOneS(id));
        }

        // POST: api/Alumno
        public IHttpActionResult Post(Alumno alumno)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.AddAlumno(alumno));
        }

        // PUT: api/Alumno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Alumno/5
        public IHttpActionResult Delete(int id)
        {   
            return Ok(studentBl.DeleteOneS(id));
        }
    }
}
