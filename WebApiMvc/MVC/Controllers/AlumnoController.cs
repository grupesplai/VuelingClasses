using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AlumnoController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Alumno
        public ActionResult Index()
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Error("Has mostrado todos los alumnos.");
            IEnumerable<MvcAlumnoModel> AlumList;
            HttpResponseMessage response = GlobalVariables.client.GetAsync("Alumno").Result;
            AlumList = response.Content.ReadAsAsync<IEnumerable<MvcAlumnoModel>>().Result;
            MvcAlumnoModel mvc = new MvcAlumnoModel() { Id = 6, Name = "ALbert", LastName = "Basag", Dni = "af323423" };

            FileManager.Usings.GetJson(AlumList.ToList());

            return View(AlumList);

        }



        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new MvcAlumnoModel());
            }
            else {
                HttpResponseMessage response = GlobalVariables.client.GetAsync("Alumno/"+  id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcAlumnoModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(MvcAlumnoModel alum)
        {
            HttpResponseMessage response = GlobalVariables.client.PostAsJsonAsync("Alumno",alum).Result;
            return RedirectToAction("Index");
        }
    }
}