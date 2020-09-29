using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Admin.Controllers
{
    public class AnalysisController : Controller
    {

        private IRepository repository;

        public AnalysisController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var dt = DateTime.Today;
            var users = repository.ApplicationUser.Where(u => u.RegisteredDay > dt && u.RegisteredDay <= DateTime.Now);


            var clicks = repository.Clicks;
            var clickedProductsToday = clicks.Where(c => c.DateClicked > dt && c.DateClicked <= DateTime.Now).OrderByDescending(c => c.ClickCount).Take(4);
            Product temp;
            List<Product> products = new List<Product>();
            foreach (var item in clickedProductsToday)
            {
                temp = ToProduct(item);
                products.Add(temp);
            }

            var todaysOrders = repository.Orders.Where(o => o.OrderDate > dt && o.OrderDate <= DateTime.Now);


            //this is for the brands and it is to be fixed


            var weekClicks = repository.Clicks.Where(c => c.DateClicked < DateTime.Now && c.DateClicked >= DateTime.Now.AddDays(-7));
            var apple = weekClicks.Where(a => a.Product.Brands.BrandName == "Iphone");
            long appleCount = apple.Count();

            return View(new AdminAnalysisViewModel()
            {
                Users = users,
                PopularProducts = clickedProductsToday,
                TodaysOrders = todaysOrders
            });
        }

        public Product ToProduct(ProductClick click)
        {
            Product product = repository.Products.Where(p => p.ProductId == click.ProductId).FirstOrDefault();
            return product;
        }
    }
}