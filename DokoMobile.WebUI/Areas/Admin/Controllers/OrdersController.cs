using DokoMobile.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private IRepository repository;
        public OrdersController(IRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View(repository.Orders);
        }
    }
}