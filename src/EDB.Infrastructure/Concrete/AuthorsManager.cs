using EDB.Domain.Abstract;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using System.Linq.Expressions;

namespace EDB.Infrastructure.Concrete
{
    public class AuthorsManager : IAuthorsService
    {
        IAuthorsRepository _authorsRepository;

        public AuthorsManager(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public void Add(Authors p)
        {
            _authorsRepository.Add(p);
        }

        public void Delete(Authors p)
        {
            _authorsRepository?.Delete(p);
        }

        public Authors GetById(Guid id)
        {
            return _authorsRepository.GetById(id);
        }

        public List<Authors> List()
        {
            return _authorsRepository.List();
        }

        public List<Authors> List(Expression<Func<Authors, bool>> filter)
        {
            return _authorsRepository.List(filter);
        }

        public void Update(Authors p)
        {
            _authorsRepository.Update(p);
        }
    }
}
