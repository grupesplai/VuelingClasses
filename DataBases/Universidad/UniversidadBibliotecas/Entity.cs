using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace UniversidadBibliotecas
{
    public class UniversityEntities : DbContext
    {
        public UniversityEntities()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UniversityEntities>());
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
    }
}
