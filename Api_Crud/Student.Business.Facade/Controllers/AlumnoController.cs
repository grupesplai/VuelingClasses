using Student.Business.Logic;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Alumno/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Alumno
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Alumno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Alumno/5
        public void Delete(int id)
        {
        }
    }
}
