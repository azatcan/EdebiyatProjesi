using EDB.Domain.Abstract;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using System.Linq.Expressions;

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
