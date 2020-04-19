using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.UI.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Category> context;

        public CategoryController(IRepository<Category> _context)
        {
            context = _context;
        }

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categorys = context.Collection().ToList();
            return View(categorys);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            context.Insert(category);
            context.Commit();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(string Id)
        {
            var category = context.Find(Id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(string Id, Category category)
        {
            var prodToEdit = context.Find(Id);

            if (prodToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                prodToEdit.Name = category.Name;                
                context.Update(prodToEdit);
                context.Commit();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Delete(string id)
        {
            var prodToDelete = context.Find(id);
            if (prodToDelete == null)
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