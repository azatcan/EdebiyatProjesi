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
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category p)
        {        
            _categoryRepository.Add(p);
        }

        public void Delete(Category p)
        {
            _categoryRepository.Delete(p);
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> List()
        {
            return _categoryRepository.List();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            return _categoryRepository.List(filter);
        }

        public void Update(Category p)
        {
            _categoryRepository.Update(p);
        }
    }
}
