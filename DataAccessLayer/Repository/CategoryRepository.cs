using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //function to create a category
        public Category Create(Category category)
        {
            _applicationDbContext.Add(category);
            _applicationDbContext.SaveChanges();

            return category;
        }

        //funciton to delete a category
        public void Delete(Category category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        //function to get a single category
        public Category? Get(int id)
        {
            Category? category = _applicationDbContext.Categories.Find(id);

            return category;
        }

        //function to get all categories
        public List<Category> GetAll()
        {
            return _applicationDbContext.Categories.ToList();
        }

        //function to update a category
        public Category? Update(Category category)
        {
            Category? existingcategory = _applicationDbContext.Categories.Find(category.Id);

            existingcategory.Name = category.Name;

            _applicationDbContext.Categories.Update(existingcategory);
            _applicationDbContext.SaveChanges();

            return existingcategory;
        }
    }
}
