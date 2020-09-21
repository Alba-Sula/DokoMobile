using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository repository;

        public ProductsController(IRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult List()
        {
            return View(repository.Products);
        }

        public ActionResult Edit(long id)
        {
            Product product = repository.Products.Where(p => p.ProductId == id).FirstOrDefault();
            ProductViewModel productVM = ProductViewModel.ToProductViewModel(product);
            return View(productVM);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //FIXES IN HERE DO NOT FORGET
                repository.SaveProducts(product);
                return RedirectToAction("List");
            }
            return View("Edit", product);
        }

        public ActionResult Create()
        {
            return View("Edit", new ProductViewModel());
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            Product product = repository.DeleteProduct(id);
            if (product != null)
            {
                TempData["mesage"] = "Product got deleted";
            }
            return RedirectToAction("List");
        }
    }
}