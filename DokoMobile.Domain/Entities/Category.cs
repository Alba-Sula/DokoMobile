using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
