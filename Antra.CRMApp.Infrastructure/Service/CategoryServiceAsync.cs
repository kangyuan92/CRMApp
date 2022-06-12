using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        public CategoryServiceAsync(ICategoryRepositoryAsync repo)
        {
            categoryRepositoryAsync = repo;
        }
        public async Task<int> AddCategoryAsync(CategoryModel model)
        {
            Category category = new Category();
            category.Name = model.Name;
            category.Description = model.Description;
            return await categoryRepositoryAsync.InsertAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var collection = await categoryRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<CategoryModel> CategoryModels = new List<CategoryModel>();
                foreach (var item in collection)
                {
                    CategoryModel model = new CategoryModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description;
                    CategoryModels.Add(model);
                }
                return CategoryModels;
            }
            return null;
        }

        public async Task<int> UpdateCategoryAsync(CategoryModel CategoryModel)
        {
            Category cg = new Category();
            cg.Id = CategoryModel.Id;
            cg.Name = CategoryModel.Name;
            cg.Description = CategoryModel.Description;
            return await categoryRepositoryAsync.UpdateAsync(cg);
        }

        public async Task<CategoryModel> GetCategoryForEditAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryModel model = new CategoryModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }
    }
}
