using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadBibliotecas
{
    public class Courses
    {
        public Courses()
        {
            Students = new HashSet<Students>();
        }
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public Subjects Subjects { get; set; }
        public Teacher Teacher { get; set; }
    }
}
