using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brands> Brands { get; set; }
        public IEnumerable<Product> Products { get; set; }

        [Display(Name = "Max Price")]
        public double MaxPrice { get; set; }

        public int Memory { get; set; }
        public int PageNo { get; set; }
        public int NoOfPages { get; set; }

    }
}