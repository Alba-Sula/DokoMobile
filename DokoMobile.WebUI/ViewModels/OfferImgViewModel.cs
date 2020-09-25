using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class OfferImgViewModel
    {
        public int OfferImgID { get; set; }
        [Display(Name = "Image Path")]
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Brand and Name")]
        [Required(ErrorMessage = "Brand and name is required")]
        public string BrandAndName { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        public HttpPostedFileBase Img { get; set; }

        public static OfferImgViewModel CreateFromOfferImg(OfferImg offerImg)
        {
            return new OfferImgViewModel()
            {
                OfferImgID = offerImg.OfferImgID,
                BrandAndName = offerImg.BrandAndName,
                Price = offerImg.Price,
                ImgPath = offerImg.ImgPath,
            };
        }
    }
}