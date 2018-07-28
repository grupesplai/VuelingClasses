using Student.Common.Logic;
using System.Collections.Generic;

namespace Student.Business.Logic
{
    public interface IBusiness
    {
        int AddAlumno(Alumno alumno);
        Alumno GetOneS(int id);
        bool DeleteOneS(int id);
        List<Alumno> GetAllS();
        Alumno UpdateOneS(Alumno alumno);
    }
}