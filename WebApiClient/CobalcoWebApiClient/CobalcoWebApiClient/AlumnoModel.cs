using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CobalcoWebApiClient
{
    class AlumnoModel
    {
        public AlumnoModel() { }
        public AlumnoModel(int id, string name, string lastName, string dni)
        {
            Id = id;
            Nombre = name;
            Apellidos = lastName;
            Dni = dni;
        }
        public AlumnoModel(string name, string lastName, string dni)
        {
            Nombre = name;
            Apellidos = lastName;
            Dni = dni;
        }
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Nombre { get; set; }
    
        [JsonProperty]
        public string Apellidos { get; set; }
        
        [JsonProperty]
        public string Dni { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as AlumnoModel;
            return model != null &&
                   Id == model.Id &&
                   Nombre == model.Nombre &&
                   Apellidos == model.Apellidos &&
                   Dni == model.Dni;
        }
        public override int GetHashCode()
        {
            var hashCode = -1407328918;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            return hashCode;
        }
    }
}
