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
        public long BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
