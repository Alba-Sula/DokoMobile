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
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brands Brands { get; set; }
    }
}
