using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vueling.Common.Layer;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.DataModel;

namespace Vueling.Infrastructure.Repository.Repository
{
    public class AlumnoRepositorycs : IRepository<AlumnoEntity>
    {
        private ColvalcoDBEntities db = new ColvalcoDBEntities();

        public AlumnoEntity Add(AlumnoEntity model)
        {
            AlumnoEntity alumnoEntity;
            try
            {
                //alumnoEntity = db.AlumnoFlyway.Add(model);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Añadir los Logs, ex.data,ex.stacktrace,ex.message
                //en capa de presentacion si se pone la inner excption, aqui no 
                
                throw new VuelingException("",ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                //Añadir los Logs
                
                throw new VuelingException("", ex.InnerException);
            }
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlumnoEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public AlumnoEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AlumnoEntity Update(AlumnoEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
