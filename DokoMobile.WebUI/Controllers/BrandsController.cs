﻿using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Controllers
{
    public class BrandsController : Controller
    {
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
            return View("Edit", new Brands());
        }

        [HttpPost]
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
