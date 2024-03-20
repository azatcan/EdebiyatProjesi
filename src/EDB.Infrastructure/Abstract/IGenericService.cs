using System.Linq.Expressions;

namespace EDB.Infrastructure.Abstract
{
    public interface IGenericService<T>
    {
        List<T> List();

        void Add(T p);
        void Delete(T p);
        void Update(T p);
        T GetById(Guid id);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
