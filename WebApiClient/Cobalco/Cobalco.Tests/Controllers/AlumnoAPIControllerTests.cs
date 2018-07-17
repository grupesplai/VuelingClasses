using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cobalco.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace Cobalco.Controllers.Integration.Tests
{
    [TestClass()]
    public class AlumnoAPIControllerTests
    {
        [TestMethod()]
        public void GetAlumnoTest()
        {
            AlumnoAPIController controller = new AlumnoAPIController();
            IQueryable<Alumno> alumno = controller.GetAlumno();
            Assert.IsTrue(alumno.Count<Alumno>() > 0);
        }

        [TestMethod()]
        public void GetAlumnoTest1()
        {
            AlumnoAPIController controller = new AlumnoAPIController();
            IHttpActionResult actionResult = controller.GetAlumno(3);

            var contenResult = actionResult as OkNegotiatedContentResult<Alumno>;
            Assert.IsNotNull(contenResult);
            Assert.IsNotNull(contenResult.Content);
            Assert.AreEqual(3,contenResult.Content.Id);
        }

        [TestMethod()]
        public void PutAlumnoTest()
        {
            AlumnoAPIController controller = new AlumnoAPIController();
            IHttpActionResult actionResult = controller.PutAlumno(3,new Alumno { Id= 3, Nombre = "Pepe",Apellidos="Cabani", Dni="159159" });
            Assert.IsNotNull(actionResult);
        }

        [TestMethod()]
        public void PostAlumnoTest()
        {
            AlumnoAPIController controller = new AlumnoAPIController();
            IHttpActionResult actionResult = controller.PostAlumno(new Alumno { Nombre="Ferran",Apellidos = "Ferrer", Dni = "2234234Z"});

            var contentResult = actionResult as CreatedAtRouteNegotiatedContentResult<Alumno>;
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(contentResult.RouteName == "DefaultApi");
        }

        [TestMethod()]
        public void DeleteAlumnoTest()
        {
            AlumnoAPIController controller = new AlumnoAPIController();
            IHttpActionResult actionResult = controller.PostAlumno(new Alumno { Nombre = "Ferran1", Apellidos = "Ferrer", Dni = "2234234Z" });
            var contentResult = actionResult as CreatedAtRouteNegotiatedContentResult<Alumno>;

            IHttpActionResult actionDeleteResult = controller.DeleteAlumno(contentResult.Content.Id);
            var contentDeleteResult = actionDeleteResult as OkNegotiatedContentResult<Alumno>;

            Assert.IsNotNull(contentDeleteResult);
            Assert.IsNotNull(contentDeleteResult.Content);

        }
    }
}