using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}