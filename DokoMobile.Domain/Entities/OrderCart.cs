using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class OrderCart
    {
        [Key]
        public long OrderCartId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public virtual Product Products { get; set; }
        public long OrderId { get; set; }
        public virtual Orders Order { get; set; }
    }
}
