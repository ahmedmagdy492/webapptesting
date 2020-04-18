using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        private ObjectCache cache;
        private readonly List<Product> products;
        public ProductRepository()
        {
            cache = MemoryCache.Default;
            products = cache["Products"] as List<Product>;
            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["Products"] = products;
        }

        public void Insert(Product prod)
        {
            products.Add(prod);
        }

        public void Update(Product prod)
        {
            var product = products.Find(p => p.Id == prod.Id);
            if(product != null)
            {
                product = prod;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public Product Find(string id)
        {
            var product = products.Find(p => p.Id == id);

            if(product != null)
            {
                return product;
            }
            throw new Exception("Product Not Found");
        }

        public IQueryable<Product> Collection()
        {
            return this.products.AsQueryable();
        }

        public void Delete(string id)
        {
            var product = products.Find(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }
            else
            {
                throw new Exception("Product Not Found");
            }            
        }
    }
}
