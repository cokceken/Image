namespace Kata4.Core.Contract.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}