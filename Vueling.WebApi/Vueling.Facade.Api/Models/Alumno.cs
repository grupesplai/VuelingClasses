using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vueling.Facade.Api.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
    }
}