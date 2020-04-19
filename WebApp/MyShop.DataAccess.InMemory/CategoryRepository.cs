using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class CategoryRepository
    {
        private ObjectCache cache;
        private readonly List<Category> categories;
        public CategoryRepository()
        {
            cache = MemoryCache.Default;
            categories = cache["Categorys"] as List<Category>;
            if (categories == null)
            {
                categories = new List<Category>();
            }
        }

        public void Commit()
        {
            cache["Categorys"] = categories;
        }

        public void Insert(Category cate)
        {
            categories.Add(cate);
        }

        public void Update(Category cate)
        {
            var category = categories.Find(p => p.Id == cate.Id);
            if (category != null)
            {
                category = cate;
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }

        public Category Find(string id)
        {
            var category = categories.Find(p => p.Id == id);

            if (category != null)
            {
                return category;
            }
            throw new Exception("Category Not Found");
        }

        public IQueryable<Category> Collection()
        {
            return this.categories.AsQueryable();
        }

        public void Delete(string id)
        {
            var category = categories.Find(p => p.Id == id);

            if (category != null)
            {
                categories.Remove(category);
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
    }
}
