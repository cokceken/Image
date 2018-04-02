using System.Collections.Generic;
using System.Linq;
using Kata4.Core.Contract.Repository;
using Kata4.Core.Model;
using Kata4.Repository.UnitOfWork;
using NHibernate;

namespace Kata4.Repository.Repository
{
    public abstract class Repository<T, TIdType> : IRepository<T, TIdType> where T : BaseModel<TIdType>
    {
        protected ISession Session => NHibernateUnitOfWork.Current.Session;
        public T Add(T item)
        {
            item.Id = (TIdType)Session.Save(item);
            return item;
        }

        public void Delete(T item)
        {
            Session.Delete(item);
        }

        public T Get(TIdType id)
        {
            return Session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Session.Query<T>().ToList();
        }

        public void Update(T item)
        {
            Session.Update(item);
        }
    }
}