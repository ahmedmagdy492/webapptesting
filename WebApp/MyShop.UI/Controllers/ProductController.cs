using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository context;

        public ProductController()
        {
            context = new ProductRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            context.Insert(product);
            context.Commit();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(string Id)
        {
            var product = context.Find(Id);

            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(string Id, Product product)
        {
            var prodToEdit = context.Find(Id);

            if(prodToEdit == null)
            {
                return HttpNotFound();                
            }
            else
            {
                if (!ModelState.IsValid)
                {                    
                    return View(product);
                }
                prodToEdit.Name = product.Name;
                prodToEdit.Category = product.Category;
                prodToEdit.Price = product.Price;
                prodToEdit.Image = product.Image;
                prodToEdit.Description = product.Description;
                context.Update(prodToEdit);
                context.Commit();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Delete(string id)
        {
            var prodToDelete = context.Find(id);
            if(prodToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}