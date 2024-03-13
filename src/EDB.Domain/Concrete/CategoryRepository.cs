using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
