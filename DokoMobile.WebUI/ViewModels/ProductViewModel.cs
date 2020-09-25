using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Product Added Time")]
        public DateTime ProductAddedTime { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Has Discount")]
        public bool HasDiscount { get; set; }
        [Display(Name = "Year of production")]
        public Nullable<DateTime> YearOfProduction { get; set; }
        [Display(Name = "Product Condition")]
        public string ProductCondition { get; set; }
        [Required(ErrorMessage = "Price is required")]
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
        [Required(ErrorMessage = "At least one img should be added")]
        [Display(Name = "Image 1")]
        public HttpPostedFileBase Img1 { get; set; }
        [Display(Name = "Image 2")]
        public HttpPostedFileBase Img2 { get; set; }
        [Display(Name = "Image 3")]
        public HttpPostedFileBase Img3 { get; set; }
        [Display(Name = "Image 4")]
        public HttpPostedFileBase Img4 { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public long CategoryId { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
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