using System.Collections.Generic;
using Student.Common.Logic;

namespace Student.DataAcces.Dao
{
    public interface IRepository
    {
        int AddAlumno(Alumno alumno);
        bool DeleteOneR(int id);
        Alumno GetOneR(int id);
        List<Alumno> GetAllR();
        bool UpdateOneR(Alumno alumno);
    }
}