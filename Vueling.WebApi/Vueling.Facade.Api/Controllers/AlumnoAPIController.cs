using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vueling.Aplication.DTO;
using Vueling.Aplication.Services;
using Vueling.Aplication.Services.Contrats;
using Vueling.Common.Layer;
using System.Resources;

namespace Vueling.Facade.Api.Controllers
{
    public class AlumnoAPIController : ApiController
    {
        //AlumnoService alumnoService = new AlumnoService(); MAL!
        private readonly IService<AlumnoDTO> alumnoService;
       
        static HttpClient client;

        public AlumnoAPIController() : this(new AlumnoService()) { }
        public AlumnoAPIController(AlumnoService alumnoService)
        {
            this.alumnoService = alumnoService;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:23053/api");
        }

        // GET: api/AlumnoAPI
        public IQueryable<AlumnoDTO> Get()
        {
            IQueryable<AlumnoDTO> alumList;
            HttpResponseMessage response = client.GetAsync("Alumno").Result;
            alumList = response.Content.ReadAsAsync<IQueryable<AlumnoDTO>>().Result;

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var alumnoJsonString = response.Content.ReadAsStringAsync();
                    var deserialize = JsonConvert.DeserializeObject<IQueryable<AlumnoDTO>>(alumnoJsonString.Result);
                    alumList = deserialize;
                }
            }
            catch { }

            return alumList;
            //devuelve iquarable<Alumno>
        }

        // GET: api/AlumnoAPI/5
        [ResponseType(typeof(AlumnoDTO))]
        public IHttpActionResult Get(int id)
        {
            AlumnoDTO alumnofinded = alumnoService.GetById(id);
            if (alumnofinded == null)
            {
                return NotFound();
            }
            return Ok(alumnofinded);
        }

        // POST: api/AlumnoAPI
        [ResponseType(typeof(AlumnoDTO))]
        public IHttpActionResult Post(AlumnoDTO alumno)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            AlumnoDTO insertedAlumno = null;
            try
            {
                insertedAlumno = alumnoService.Add(alumno);
            }
            catch (VuelingException ex)
            {
                return Content(HttpStatusCode.NotFound, Resource0.NOT_FOUND);
            }

            return CreatedAtRoute("DefaultApi", new { id = insertedAlumno.Id }, insertedAlumno);
            //devuelve el id & alumno
        }

        // PUT: api/AlumnoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, AlumnoDTO alumno)
        {
            if (!ModelState.IsValid)
            {   return BadRequest(ModelState);  }
            if (id != alumno.Id)
            {   return BadRequest();  }

            AlumnoDTO updatedAlumno = null;
            try
            {
                updatedAlumno = alumnoService.Update(alumno);
            }
            catch (VuelingException ex)
            {
                //http error
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/AlumnoAPI/5
        [ResponseType(typeof(AlumnoDTO))]
        public IHttpActionResult Delete(int id)
        {
            int idEliminated = 0;
            try
            {
                if (id != 0)
                {
                    idEliminated = alumnoService.Delete(id);
                }
                else
                {
                    //return http error
                }
                
            }
            catch (VuelingException)
            {

                throw;
            }
            return Ok(idEliminated);
            //devuelve ok y el id
        }
    }
}