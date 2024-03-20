using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;

namespace EDB.Domain.Concrete
{
    public class StorysRepository:GenericRepository<Storys,DataContext>,IStorysRepository
    {
        private DataContext context;
        public StorysRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
