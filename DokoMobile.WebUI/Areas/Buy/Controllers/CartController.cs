﻿using DokoMobile.Domain.Abstract;
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
            if (returnUrl == null)
            {
                returnUrl = "/";
            }
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

            return RedirectToAction("Index", "Cart", returnUrl);
        }

        public ActionResult RemoveFromCart(long productId, string returnUrl)
        {
            Product product = repo.Products.Where(p => p.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                GetCart().RemoveCartLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }



        public PartialViewResult Summary()
        {
            Cart cart = GetCart();

            return PartialView(cart);
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