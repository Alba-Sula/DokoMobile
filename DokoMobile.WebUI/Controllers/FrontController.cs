using DokoMobile.Domain.Abstract;
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

        public ActionResult MainPage()
        {
            var caruselOffer = repository.OfferImgs;
            var products = repository.Products.OrderBy(x => x.ProductAddedTime).Take(20);
            return View(new MainPgViewModel()
            {
                OfferImgs = caruselOffer,
                Products = products,
            });
        }
    }
}