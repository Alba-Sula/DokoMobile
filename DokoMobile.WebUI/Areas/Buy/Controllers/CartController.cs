using DokoMobile.Domain;
using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Buy.Controllers
{ 
//    [Authorize(Roles ="User")]
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
        [Authorize(Roles = "User")]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            string authenticatedUserId = this.User.Identity.GetUserId();
            var user = userManager.FindById(authenticatedUserId);
            string toEmail = user.Email;

            Cart cart = (Cart)Session["Cart"];
            var totalPrice = cart.TotalValue();
            var totalQuantity = cart.Lines.Sum(x => x.Quantity);

            //creating the order
            Orders order = new Orders()
            {
                OrderStatusId = 1,
                FullName = shippingDetails.FullName,
                Address = shippingDetails.Address,
                PhoneNumber = shippingDetails.PhoneNumber,
                Email = toEmail,
                OrderDate = DateTime.Now,
                UserId = authenticatedUserId
            };

            repo.SaveOrder(order);
            Orders savedOrder = repo.Orders.Last();
            OrderCart orderCart = new OrderCart();
            List<OrderCart> orderDetailsList = new List<OrderCart>();

            foreach (var item in cart.Lines)
            {
                orderCart.OrderId = savedOrder.OrderId;
                orderCart.ProductId = item.Product.ProductId;
                orderCart.Quantity = item.Quantity;
                orderCart.Products = repo.Products.Where(p => p.ProductId == item.Product.ProductId).FirstOrDefault();

                orderDetailsList.Add(orderCart);
                repo.SaveOrderCarts(orderCart);

            }
            cart.ClearCart();

            bool send;
            string emailbody = "<h3>Hello <strong>" + savedOrder.FullName + "</strong></h3><br /><p>Thank you for trusting us, we will send your goods asap!</p><br /><p>Shipping details</p><p>Name: " + savedOrder.FullName + "</p><p>Address:" + savedOrder.Address + "</p><p>Phone Number:" + savedOrder.PhoneNumber + "</p><br /><p>Summary of your order:</p><p>You bought " + totalQuantity + " items with a total price of " + totalPrice + ".</p><br /><h3>Regards, Doko Mobile</h3>";

            send = SendOrderEmail(toEmail, "New Order", emailbody);
            ViewBag.Sended = send;
            return View("FinishedOrder");
        }




        public bool SendOrderEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["senderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage email = new MailMessage(senderEmail, toEmail, subject, emailBody);
                email.IsBodyHtml = true;
                email.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(email);
                return true;
            }
            catch (Exception ex)
            {
                string ecept = ex.ToString();
                return false;
            }
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