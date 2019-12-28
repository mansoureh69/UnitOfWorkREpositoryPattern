using UnitOfWorkRepository.Domain;

namespace UnitOfWorkRepositoryPattern.DAL.EF
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
        void Dispose();
    }
}
