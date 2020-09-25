using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            this.ProductAddedTime = DateTime.Now;
            this.HasDiscount = false;
        }
        [Key]
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
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public long CategoryId { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is required")]
        public long BrandId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brands Brands { get; set; }
    }
}
