﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDB.Domain.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> List();

        void Add(T p);
        void Delete(T p);
        void Update(T p);
        T GetById(Guid id);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
