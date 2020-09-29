using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class Orders
    {
        public Orders()
        {
            this.OrderDate = DateTime.Now;
            this.CartElements = new HashSet<OrderCart>();
        }

        [Key]
        public long OrderId { get; set; }
        [Display(Name = "Status")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus Status { get; set; }
        [Required(ErrorMessage = "Your name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Your address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Your phone number is required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Your email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<OrderCart> CartElements { get; set; }
    }
}
