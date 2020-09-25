using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class Brands
    {
        [Key]
        [Display(Name ="Brand Id")]
        public long BrandId { get; set; }
        [Required(ErrorMessage ="Brand name is required")]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
    }
}
