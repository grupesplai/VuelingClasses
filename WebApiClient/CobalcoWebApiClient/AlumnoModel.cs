using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobalcoWebApiClient
{
    class AlumnoModel
    {
        public AlumnoModel(int id, string name, string lastName, string dni)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Dni = dni;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as AlumnoModel;
            return model != null &&
                   Id == model.Id &&
                   Name == model.Name &&
                   LastName == model.LastName &&
                   Dni == model.Dni;
        }
        public override int GetHashCode()
        {
            var hashCode = -1407328918;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            return hashCode;
        }
    }
}
