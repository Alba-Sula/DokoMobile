using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DokoMobile.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DokoMobile.Domain
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Brands> Brands { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<OfferImg> OfferImgs { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}