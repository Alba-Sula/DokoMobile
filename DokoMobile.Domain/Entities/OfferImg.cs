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
        public int OfferImgID { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
        public string BrandAndName { get; set; }
    }
}
