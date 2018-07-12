using System;
using System.Linq;
using UniversidadBibliotecas;

namespace Universidad
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uni = new UniversityEntities())
            {
                var x = uni.Students.ToList();
            }
        }
    }
}
