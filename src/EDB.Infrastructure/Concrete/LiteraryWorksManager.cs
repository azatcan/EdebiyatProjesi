using EDB.Domain.Abstract;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Infrastructure.Concrete
{
    public class LiteraryWorksManager : ILiteraryWorksService
    {
        ILiteraryWorksRepository _literaryWorksRepository;

        public LiteraryWorksManager(ILiteraryWorksRepository literaryWorksRepository)
        {
            _literaryWorksRepository = literaryWorksRepository;
        }

        public void Add(LiteraryWorks p)
        {
            _literaryWorksRepository.Add(p);
        }

        public void Delete(LiteraryWorks p)
        {
            _literaryWorksRepository?.Delete(p);
        }

        public LiteraryWorks GetById(Guid id)
        {
            return _literaryWorksRepository.GetById(id);
        }

        public List<LiteraryWorks> List()
        {
            return _literaryWorksRepository.List();
        }

        public List<LiteraryWorks> List(Expression<Func<LiteraryWorks, bool>> filter)
        {
            return _literaryWorksRepository.List(filter);
        }

        public void Update(LiteraryWorks p)
        {
            _literaryWorksRepository.Update(p);
        }
    }
}
