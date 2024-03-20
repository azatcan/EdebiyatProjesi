using EDB.Domain.Abstract;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace EDB.Infrastructure.Concrete
{
    public class StorysManager : IStorysService
    {
        IStorysRepository _storysRepository;

        public StorysManager(IStorysRepository storysRepository)
        {
            _storysRepository = storysRepository;
        }

        public void Add(Storys p)
        {
            _storysRepository.Add(p);
        }

        public void Delete(Storys p)
        {
            _storysRepository.Delete(p);
        }

        public Storys GetById(Guid id)
        {
            return _storysRepository.GetById(id);
        }

        public List<Storys> List()
        {
            return _storysRepository.List();
        }

        public List<Storys> List(Expression<Func<Storys, bool>> filter)
        {
            return _storysRepository.List(filter);
        }

        public void Update(Storys p)
        {
            _storysRepository.Update(p);
        }
    }
}
