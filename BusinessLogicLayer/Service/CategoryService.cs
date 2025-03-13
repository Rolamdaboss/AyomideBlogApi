using BusinessLogicLayer.IServices;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class categorieservice : Icategorieservice
    {
        private readonly IUnitOfWork _unitOfWork;

        public categorieservice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category? Createcategory(Category category, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(category.Name))
            {
                message = "Name can not be empty";
                return null;
            }

            message = "Created successfully";

            return _unitOfWork.categoryRepository.Create(category);
        }

        public bool Deletecategory(int id, out string message)
        {
            //checking if the id is valid
            if (id <= 0)
            {
                message = "Invalid ID";
                return false;
            }

            Category? category = _unitOfWork.categoryRepository.Get(id);

            //checking if the id exists
            if (category == null)
            {
                message = "category not found";
                return false;
            }

            _unitOfWork.categoryRepository.Delete(category);

            message = "category deleted successfully";
            return true;
        }

        public List<Category> GetAllcategory()
        {
            return _unitOfWork.categoryRepository.GetAll();
        }

        public Category? Getcategory(int id)
        {
            //checking if the id is valid
            if (id <= 0)
            {
                return null;
            }

            Category? category = _unitOfWork.categoryRepository.Get(id);

            //checking if category exists
            if (category == null)
            {
                return null;
            }

            return category;
        }

        public Category? Updatecategory(Category category, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(category.Name))
            {
                message = "Name can not be empty";
                return null;
            }

            Category? updatedcategory = _unitOfWork.categoryRepository.Update(category);

            //checking if category exists
            if (updatedcategory is null)
            {
                message = "category does not exist";
                return null;
            }

            message = "category updated successfully";
            return updatedcategory;

        }
    }
}
