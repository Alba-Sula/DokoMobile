using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokoMobile.WebUI.ViewModels
{
    public class OfferImgViewModel
    {
        public int OfferImgID { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
        public string BrandAndName { get; set; }
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