using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class ProductClick
    {
        public ProductClick()
        {
            this.DateClicked = DateTime.Now;
        }
        [Key]
        public long ClickId { get; set; }
        public long ProductId { get; set; }
        public long ClickCount { get; set; }
        public DateTime DateClicked { get; set; }

        public virtual Product Product { get; set; }
    }
}
