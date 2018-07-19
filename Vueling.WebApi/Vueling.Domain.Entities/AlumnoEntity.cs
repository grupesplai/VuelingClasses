using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Domain.Entities
{
    public class AlumnoEntity
    {//aqui logica para calcular edad!, automapeado de service pero que viene del DTO
        //
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public int Years { get; set; }// falta en la bbdd
        public DateTime Birhday{ get; set; }//falta en la bbdd, altertable
    }
}
