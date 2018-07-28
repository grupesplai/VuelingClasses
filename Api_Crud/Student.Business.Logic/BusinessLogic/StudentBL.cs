using Student.Common.Logic;
using Student.DataAcces.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;

        public StudentBL(ILogger Logger, IRepository dao)
        {
            this.Log = Logger;
            this.repository = dao;
        }

        public int AddAlumno(Alumno alumno)
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.AddAlumno(alumno);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
