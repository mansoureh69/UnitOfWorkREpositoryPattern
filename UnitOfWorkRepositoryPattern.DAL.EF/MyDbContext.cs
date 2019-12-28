using Microsoft.EntityFrameworkCore;
using UnitOfWorkRepository.Domain;

namespace UnitOfWorkRepositoryPattern.DAL.EF
{
    public class MyDbContext : DbContext
    {
        public  DbSet<Person> Persons{ get; set; }
      
    }
}
