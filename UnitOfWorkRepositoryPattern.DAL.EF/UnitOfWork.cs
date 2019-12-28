using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkRepository.Domain;
using UnitOfWorkRepositoryPattern.Contracts;

namespace UnitOfWorkRepositoryPattern.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
        #region Repositories
        public IRepository<Person> PersonRepository => new GenericRepository<Person>(_dbContext);
      
        #endregion
        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
