using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class ApiOrders
    {
        public long OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public IEnumerable<OrderCart> CartElements { get; set; }
        public static ApiOrders ToApiOrders (Orders o)
        {
            return  new ApiOrders()
            {
                OrderId = o.OrderId,
                OrderStatusId = o.OrderStatusId,
                FullName = o.FullName,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                OrderDate = o.OrderDate,
                UserId = o.UserId,
                // CartElements = o.CartElements.AsQueryable().Select(OrderCartViewModel.ViewModel),
            };
        }
        public static Expression<Func<Orders, ApiOrders>> ViewModel
        {
            get
            {
                return o => new ApiOrders()
                {
                    OrderId =o.OrderId,
                    OrderStatusId = o.OrderStatusId,
                    FullName =o.FullName,
                    Address =o.Address,
                    PhoneNumber = o.PhoneNumber,
                    Email = o.Email,
                    OrderDate = o.OrderDate,
                    UserId  = o.UserId,
                   // CartElements = o.CartElements.AsQueryable().Select(OrderCartViewModel.ViewModel),
                };
            }
        }
    }
}