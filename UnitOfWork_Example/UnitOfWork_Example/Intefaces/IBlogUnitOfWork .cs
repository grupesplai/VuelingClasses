using UnitOfWork_Example.Modelo;
using System.Data.Entity;

namespace UnitOfWork_Example.Intefaces
{
    public interface IBlogUnitOfWork : IEntityFrameworkUnitOfWork
    {
        IDbSet<Post> Posts { get; }
        IDbSet<Category> Categories { get; }
        IDbSet<Comment> Comments { get; }
    }
}
