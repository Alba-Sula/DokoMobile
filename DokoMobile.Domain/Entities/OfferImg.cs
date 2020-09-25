using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class OfferImg
    {
        [Key]
        [Display(Name ="Image Offer Id")]
        public int OfferImgID { get; set; }
        [Display(Name ="Image")]
        [Required(ErrorMessage ="Image is required")]
        public string ImgPath { get; set; }
        [Required(ErrorMessage ="Price is required")]
        public double Price { get; set; }
        [Display(Name ="Brand and Name")]
        [Required(ErrorMessage ="Brand and name is required")]
        public string BrandAndName { get; set; }
    }
}
