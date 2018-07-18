using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobalco.Models
{//clase para ejercicio automapper
    public class AlumnoViewModel
    {
        //public int Id { get; set; }//no quiero mostrar el ID
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
    }
}