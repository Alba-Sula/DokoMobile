using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.ProductAddedTime = DateTime.Now;
        }
        public long ProductId { get; set; }
        public DateTime ProductAddedTime { get; set; }
        public string Name { get; set; }
        public bool HasDiscount { get; set; }
        public Nullable<DateTime> YearOfProduction { get; set; }
        public string ProductCondition { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Display { get; set; }
        public string RAM { get; set; }
        public string Processor { get; set; }
        public int? Batery { get; set; }
        public string OS { get; set; }
        public int? Memory { get; set; }
        public string ImgPath1 { get; set; }
        public string ImgPath2 { get; set; }
        public string ImgPath3 { get; set; }
        public string ImgPath4 { get; set; }
        public HttpPostedFileBase Img1 { get; set; }
        public HttpPostedFileBase Img2 { get; set; }
        public HttpPostedFileBase Img3 { get; set; }
        public HttpPostedFileBase Img4 { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }

        public static ProductViewModel ToProductViewModel(Product p)
        {
            return new ProductViewModel()
            {
                ProductId = p.ProductId,
                ProductAddedTime = p.ProductAddedTime,
                Name = p.Name,
                HasDiscount = p.HasDiscount,
                YearOfProduction = p.YearOfProduction,
                ProductCondition = p.ProductCondition,
                Price = p.Price,
                Color = p.Color,
                Description = p.Description,
                Display = p.Display,
                RAM = p.RAM,
                Processor = p.Processor,
                Batery = p.Batery,
                OS = p.OS,
                Memory = p.Memory,
                ImgPath1 = p.ImgPath1,
                ImgPath2 = p.ImgPath2,
                ImgPath3 = p.ImgPath3,
                ImgPath4 = p.ImgPath4,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
            };
        }

        public static Product ToProduct(ProductViewModel p)
        {
            return new Product()
            {
                ProductId = p.ProductId,
                ProductAddedTime = p.ProductAddedTime,
                Name = p.Name,
                HasDiscount = p.HasDiscount,
                YearOfProduction = p.YearOfProduction,
                ProductCondition = p.ProductCondition,
                Price = p.Price,
                Color = p.Color,
                Description = p.Description,
                Display = p.Display,
                RAM = p.RAM,
                Processor = p.Processor,
                Batery = p.Batery,
                OS = p.OS,
                Memory = p.Memory,
                ImgPath1 = p.ImgPath1,
                ImgPath2 = p.ImgPath2,
                ImgPath3 = p.ImgPath3,
                ImgPath4 = p.ImgPath4,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
            };
        }
    }
}