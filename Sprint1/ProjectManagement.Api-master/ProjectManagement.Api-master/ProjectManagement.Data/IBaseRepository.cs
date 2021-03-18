using ProjectManagement.Entities;
using System.Linq;

namespace ProjectManagement.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();

        T Get(long id);

        T Add(T entity);

        T Update(T entity);

        void Delete(long id);

    }
}
