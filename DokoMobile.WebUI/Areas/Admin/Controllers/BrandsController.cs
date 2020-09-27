using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brandss
        private IRepository repository;
        public BrandsController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult List()
        {
            return View(repository.Brands);
        }

        public ActionResult Edit(long id)
        {
            Brands brand = repository.Brands.Where(b => b.BrandId == id).FirstOrDefault();
            ViewBag.Categories = repository.Categories.ToList();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brands brand)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBrands(brand);
                return RedirectToAction("List");
            }
            else
            {
                return View(brand.BrandId);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Categories = repository.Categories.ToList();
            return View("Edit", new Brands());
        }

        public ActionResult Delete(long id)
        {
            Brands brand = repository.DeleteBrand(id);
            if (brand != null)
            {
                TempData["message"] = string.Format("{0} was deleted", brand.BrandName);
            }
            return RedirectToAction("List");
        }
    }
}