using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Abstract
{
    public interface IOrderProccesser
    {
        void ProccessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
