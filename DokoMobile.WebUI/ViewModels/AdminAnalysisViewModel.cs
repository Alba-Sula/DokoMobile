using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class AdminAnalysisViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Product> ProductBrands { get; set; }
        public IEnumerable<ProductClick> PopularProducts { get; set; }

        //do not forget the orders here

    }
}