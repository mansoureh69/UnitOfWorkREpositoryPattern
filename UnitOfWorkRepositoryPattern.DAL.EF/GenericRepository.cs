using System.Linq;
using UnitOfWorkRepositoryPattern.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkRepositoryPattern.Contracts
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _dbContext;
        private DbSet<T> DbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => DbSet;
        public GenericRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
