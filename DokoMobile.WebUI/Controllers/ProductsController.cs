using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (product.Img1 != null)
                {
                    product.ImgPath1 = DbPath(product.Img1);
                }

                if (product.Img2 != null)
                {
                    product.ImgPath2 = DbPath(product.Img2);
                }

                if (product.Img3 != null)
                {
                    product.ImgPath3 = DbPath(product.Img3);
                }

                if (product.Img4 != null)
                {
                    product.ImgPath4 = DbPath(product.Img4);
                }
                Product productDb = ProductViewModel.ToProduct(product);
                repository.SaveProducts(productDb);
                return RedirectToAction("List");
            }
            return View("Edit", product);
        }

        public string DbPath(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            fileName = "dokoMobile-" + fileName;
            string fileNameSave = Path.Combine(Server.MapPath("~/Images/"), fileName);
            file.SaveAs(fileNameSave);
            return "/Images/" + fileName;
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