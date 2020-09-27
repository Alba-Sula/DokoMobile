using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class ProductDTViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}