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
        [Display(Name ="Category Id")]
        public long CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
    }
}
