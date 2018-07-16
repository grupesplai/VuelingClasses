using System;
using System.Collections.Generic;
using System.Data.Entity;
using UnitOfWork_Example.Intefaces;
using UnitOfWork_Example.Modelo;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace UnitOfWork_Example.AccesoDatos
{
    public class  BlogUnitOfWork : DbContext, IBlogUnitOfWork
    {
        public BlogUnitOfWork() { }

        // Implementación de IBlogUnitOfWork

        IDbSet<Post> posts;
        public IDbSet<Post> Posts
        {
            get
            {
                if (posts == null)
                    posts = base.Set<Post>();
                return posts;
            }
        }


        IDbSet<Category> categories;
        public IDbSet<Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = base.Set<Category>();
                return categories;
            }
        }


        IDbSet<Comment> comments;
        public IDbSet<Comment> Comments
        {
            get
            {
                if (comments == null)
                    comments = base.Set<Comment>();
                return comments;
            }
        }

        // Implementación de IEntityFrameworkUnitOfWork

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            if (base.Entry<TEntity>(entity).State == EntityState.Detached)
            {
                base.Set<TEntity>().Attach(entity);
            }
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        // Implementación de IUnitOfWork

        public void SetModified<TEntity>(TEntity entity) where TEntity : class
        {
            base.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });
                }
            } while (saveFailed);
        }

        public void Rollback()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        // Sobreescibimos OnModelCreating de DdContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Post>().Property(po => po.Text).IsMaxLength();
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
