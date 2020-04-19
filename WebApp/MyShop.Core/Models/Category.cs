using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public Category()
        {
            Id = Guid.NewGuid().ToString("N");
            Products = new List<Product>();
        }
    }
}
