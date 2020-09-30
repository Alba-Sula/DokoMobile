using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class OrderCartViewModel
    {
        public long OrderCartId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }

        public static Expression<Func<OrderCart, OrderCartViewModel>> ViewModel
        {
            get
            {
                return o => new OrderCartViewModel()
                {
                    OrderCartId = o.OrderCartId,
                    Quantity = o.Quantity,
                    ProductId = o.ProductId,
                    OrderId = o.OrderId,
                };
            }
        }
    }
}