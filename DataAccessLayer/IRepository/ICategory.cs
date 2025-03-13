using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ICategory
    {
        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Object of category</returns>
        Category Create(Category category);

        /// <summary>
        /// Get all category
        /// </summary>
        /// <returns>List of categories</returns>
        List<Category> GetAll();

        /// <summary>
        /// Delete category
        /// </summary>
        void Delete(Category category);

        /// <summary>
        /// Get a single category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Object of category</returns>
        Category? Get(int id);

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Object of category</returns>
        Category? Update(Category category);
    }
}
