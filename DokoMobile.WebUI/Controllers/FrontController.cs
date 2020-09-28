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
    public class FrontController : Controller
    {
        IRepository repository;
        public FrontController(IRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult MainPage(int PageNo = 1)
        {
            var caruselOffer = repository.OfferImgs;
            var products = repository.Products.OrderBy(x => x.ProductAddedTime);

            int NoOfRecordsPerPage = 16;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count()) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            var productss = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage);

            return View(new MainPgViewModel()
            {
                OfferImgs = caruselOffer,
                Products = productss,
            });
        }

        public ActionResult Smartphone(int PageNo = 1)
        {
            IEnumerable<Product> smartphones = repository.Products.Where(p => p.Category.CategoryName == "Smartphone").OrderBy(p => p.ProductAddedTime);

            return View(smartphones);
        }

        public ActionResult Accessories(int PageNo = 1)
        {
            IEnumerable<Product> accessories = repository.Products.Where(p => p.Category.CategoryName == "Accessories").OrderBy(p => p.ProductAddedTime);

            return View(accessories);
        }

        public ActionResult Gaming(int PageNo = 1)
        {
            IEnumerable<Product> gaming = repository.Products.Where(p => p.Category.CategoryName == "Gaming").OrderBy(p => p.ProductAddedTime);

            return View(gaming);
        }

        public ActionResult Services(int PageNo = 1)
        {
            IEnumerable<Product> services = repository.Products.Where(p => p.Category.CategoryName == "Services").OrderBy(p => p.ProductAddedTime);

            return View(services);
        }
        public ActionResult ProductItem(long id)
        {
            Product dbProduct = repository.Products.Where(p => p.ProductId == id).FirstOrDefault();
            repository.SaveClick(id);
            return View(dbProduct);
        }

        public ActionResult Search(string search = "", int PageNo = 1)
        {

            var products = repository.Products.Where(x => x.Name.Contains(search)).OrderBy(x => x.ProductAddedTime);

            int NoOfRecordsPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count()) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            var productss = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage);

            var categories = repository.Categories;
            var brands = repository.Brands;

            return PartialView("Search", new SearchViewModel()
            {
                Search = search,
                Products = productss,
                Categories = categories,
                Brands = brands,
                PageNo = PageNo,
                NoOfPages = NoOfPages
            });
        }

        [HttpPost]
        public ActionResult CustomSearch(int? CategoryId, int? BrandId, int? maxPrice, int? searchMemory)
        {
            var products = repository.Products.Where(p => p.CategoryId == CategoryId);
            products = products.Where(p => p.BrandId == BrandId);
            if (maxPrice != null && maxPrice > 0)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }
            if (searchMemory != null && searchMemory > 0)
            {
                products = products.Where(p => p.Memory == searchMemory);
            }
            //IEnumerable<Product> products = repository.Products.Where(p => p.CategoryId == CategoryId)
            //    .Where(p => p.BrandId == BrandId)
            //    .Where(p => p.Price < maxPrice);
            return PartialView("CustomSearch", products);
        }

    }
}