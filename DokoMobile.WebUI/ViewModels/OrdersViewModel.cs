using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<Orders> DeliverOrders { get; set; }
        public IEnumerable<Orders> DeliveringOrders { get; set; }
        public IEnumerable<Orders> DeliveredOrders { get; set; }

    }
}