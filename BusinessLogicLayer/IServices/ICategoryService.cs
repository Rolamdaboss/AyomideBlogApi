using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface Icategorieservice
    {
        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <returns>Object of category</returns>
        Category? Createcategory(Category category, out string message);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of category</returns>
        List<Category> GetAllcategory();

        /// <summary>
        /// Get a sungle category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of category</returns>
        Category? Getcategory(int id);

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category? Updatecategory(Category category, out string message);

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean true or false</returns>
        bool Deletecategory(int id, out string message);
    }
}
