using MyShop.Core;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseModel
    {
        private ObjectCache cache;
        private List<T> EntityData;
        private string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            cache = MemoryCache.Default;
            EntityData = cache[className] as List<T>;
            if (EntityData == null)
            {
                EntityData = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = EntityData;
        }

        public void Insert(T prod)
        {
            EntityData.Add(prod);
        }

        public void Update(T prod)
        {
            var product = EntityData.Find(p => p.Id == prod.Id);
            if (product != null)
            {
                product = prod;
            }
            else
            {
                throw new Exception("T Not Found");
            }
        }

        public T Find(string id)
        {
            var product = EntityData.Find(p => p.Id == id);

            if (product != null)
            {
                return product;
            }
            throw new Exception("Product Not Found");
        }

        public IQueryable<T> Collection()
        {
            return this.EntityData.AsQueryable();
        }

        public void Delete(string id)
        {
            var product = EntityData.Find(p => p.Id == id);

            if (product != null)
            {
                EntityData.Remove(product);
            }
            else
            {
                throw new Exception("T Not Found");
            }
        }


    }
}
