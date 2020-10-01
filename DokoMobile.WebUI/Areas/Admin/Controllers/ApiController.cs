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
    public class ApiController : Controller
    {
        IRepository repository;
        public ApiController(IRepository repository)
        {
            this.repository = repository;
        }
        public List<ApiOrders> GetOrders()
        {
            List<Orders> orders = (List<Orders>)repository.Orders;
            List<ApiOrders> apiOrders = new List<ApiOrders>();
            foreach (var item in orders)
            {
                apiOrders.Add(ApiOrders.ToApiOrders(item));
            }

            return apiOrders;
        }
    }
}