using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;

namespace EDB.Domain.Concrete
{
    public class AuthorsRepository: GenericRepository<Authors, DataContext>, IAuthorsRepository 
    {
        private DataContext context;
        public AuthorsRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
