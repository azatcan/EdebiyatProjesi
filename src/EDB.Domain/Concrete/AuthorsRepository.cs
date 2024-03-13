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
    public class AuthorsRepository: GenericRepository<Authors, DataContext>, IAuthorsRepository 
    {
        private DataContext context;
        public AuthorsRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
