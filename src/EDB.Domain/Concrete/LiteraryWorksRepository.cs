using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;

namespace EDB.Domain.Concrete
{
    public class LiteraryWorksRepository:GenericRepository<LiteraryWorks,DataContext>,ILiteraryWorksRepository
    {
        private DataContext context;
        public LiteraryWorksRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
