using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;

namespace EDB.Domain.Concrete
{
    public class CategoryRepository : GenericRepository<Category, DataContext>, ICategoryRepository
    {
        private DataContext context;
        public CategoryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
