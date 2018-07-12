using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadBibliotecas
{
    
    public class Subjects
    {
        public Subjects()
        {
            Courses = new HashSet<Courses>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
