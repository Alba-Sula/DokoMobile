using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Abstract
{
    public interface IRepository
    {
        //categories
        IEnumerable<Category> Categories { get; set; }
        void SaveCategory(Category category);
        Category DeleteCategory(long categoryId);

        //ordercart
        IEnumerable<OrderCart> OrderCart { get; set; }
        void SaveOrderCarts(OrderCart orderCart);

        //orderstatus
        IEnumerable<OrderStatus> OrderStatus { get; set; }

        //orders
        IEnumerable<Orders> Orders { get; set; }
        void SaveOrder(Orders order);

        //brands
        IEnumerable<Brands> Brands { get; set; }
        void SaveBrands(Brands brand);
        Brands DeleteBrand(long id);

        //products
        IEnumerable<Product> Products { get; set; }
        void SaveProducts(Product product);
        Product DeleteProduct(long id);

        //offerImgs
        IEnumerable<OfferImg> OfferImgs { get; set; }
        string SaveOfferImgs(OfferImg offerImg);
        OfferImg DeleteOfferImg(int id);

        //clicks
        IEnumerable<ProductClick> Clicks { get; set; }
        void SaveClick(long id);


        //identity
        IEnumerable<ApplicationUser> ApplicationUser { get; set; }
    }
}
