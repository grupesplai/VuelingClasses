using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadBibliotecas
{
    
    public class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Courses>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
