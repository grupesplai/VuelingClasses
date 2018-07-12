using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadBibliotecas
{

    public class Students
    {
        public Students()
        {
            Courses = new HashSet<Courses>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Courses> Courses { get; set; }
       
    }
}
