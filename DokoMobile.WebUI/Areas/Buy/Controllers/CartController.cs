using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Buy.Controllers
{
    public class CartController : Controller
    {
        private IRepository repo;

        public CartController(IRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new CartViewModel()
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl,
            });

        }

        public ActionResult AddToCart(long productId, string returnUrl)
        {
            Product product = repo.Products.Where(p => p.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                GetCart().AddToCart(product, 1);
            }
            //do not forget the return url to return in the page where u already made that add to cart thing

            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(long productId, string returnUrl)
        {
            Product product = repo.Products.Where(p => p.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                GetCart().RemoveCartLine(product);
            }
            //do not forget the return url to return in the page where u already made that add to cart thing

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}