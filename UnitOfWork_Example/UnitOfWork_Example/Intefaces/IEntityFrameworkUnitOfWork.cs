using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace UnitOfWork_Example.Intefaces
{
    public interface IEntityFrameworkUnitOfWork : IUnitOfWork
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Attach<TEntity>(TEntity item) where TEntity : class;
        void SetModified<TEntity>(TEntity item) where TEntity : class;
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);
        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
