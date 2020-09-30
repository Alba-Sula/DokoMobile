using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DokoMobile.WebUI.Areas.Admin
{
    public class ApiOrdersController : ApiController
    {
        IRepository repository;
        public ApiOrdersController(IRepository repository)
        {
            this.repository = repository;
        }
        //public List<ApiOrders> GetOrders()
        //{
        //    List<Orders> orders =(List<Orders>)repository.Orders;

        //    List<ApiOrders> apiOrders = ApiOrders.ToApiOrders(orders);
        //}
    }
}
