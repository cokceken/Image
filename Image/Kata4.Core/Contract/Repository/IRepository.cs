using System.Collections.Generic;
using Kata4.Core.Model;

namespace Kata4.Core.Contract.Repository
{
    public interface IRepository<T, in TIdType> where T : BaseModel<TIdType>
    {
        T Get(TIdType id);
        void Update(T item);
        T Add(T item);
        IEnumerable<T> GetAll();
        void Delete(T item);
    }
}
