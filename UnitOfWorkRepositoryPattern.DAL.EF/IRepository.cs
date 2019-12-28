using System.Linq;

namespace UnitOfWorkRepositoryPattern.DAL.EF
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
    }
}
