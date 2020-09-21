using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository repository;

        public CategoriesController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult List()
        {
            return View(repository.Categories);
        }

        public ActionResult Edit(long id)
        {
            Category category = repository.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                return RedirectToAction("List");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Create()
        {
            return View("Edit", new Category());
        }


        [HttpPost]
        public ActionResult Delete(long id)
        {
            Category deletedCategory = repository.DeleteCategory(id);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedCategory.CategoryName);
            }
            return RedirectToAction("List");
        }


    }
}