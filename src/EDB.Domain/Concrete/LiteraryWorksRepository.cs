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
    public class LiteraryWorksRepository:GenericRepository<LiteraryWorks,DataContext>,ILiteraryWorksRepository
    {
        private DataContext context;
        public LiteraryWorksRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
