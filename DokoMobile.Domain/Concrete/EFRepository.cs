using DokoMobile.Domain;
using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Concrete
{
    public class EFRepository : IRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Product> Products { get { return context.Products; } set { } }
        public IEnumerable<Brands> Brands { get { return context.Brands; } set { } }
        public IEnumerable<Category> Categories { get { return context.Categories; } set { } }
        public IEnumerable<OfferImg> OfferImgs { get { return context.OfferImgs; } set { } }
        public IEnumerable<ApplicationUser> ApplicationUser { get { return context.Users; } set { } }


        //categories
        public void SaveCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbCategory = context.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
                if (dbCategory != null)
                {
                    dbCategory.CategoryName = category.CategoryName;
                }
            }
            context.SaveChanges();
        }

        public Category DeleteCategory(long categoryId)
        {
            Category dbCategory = context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            if (dbCategory != null)
            {
                context.Categories.Remove(dbCategory);
                context.SaveChanges();
            }
            return dbCategory;
        }

        //brands
        public void SaveBrands(Brands brand)
        {
            if (brand.BrandId == 0)
            {
                context.Brands.Add(brand);
            }
            else
            {
                Brands dbBrand = context.Brands.Where(b => b.BrandId == brand.BrandId).FirstOrDefault();
                if (dbBrand != null)
                {
                    dbBrand.BrandName = brand.BrandName;
                }
            }
            context.SaveChanges();
        }

        public Brands DeleteBrand(long id)
        {
            Brands brand = context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
            if (brand != null)
            {
                context.Brands.Remove(brand);
                context.SaveChanges();
            }
            return brand;
        }

        //products
        public void SaveProducts(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.YearOfProduction = product.YearOfProduction;
                    dbProduct.ProductCondition = product.ProductCondition;
                    dbProduct.Price = product.Price;
                    dbProduct.Color = product.Color;
                    dbProduct.Description = product.Description;
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(long id)
        {
            Product product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        //offerImgs
        public string SaveOfferImgs(OfferImg offerImg)
        {
            bool changed = false;
            string pathToDelete = "";
            if (offerImg.OfferImgID == 0)
            {
                context.OfferImgs.Add(offerImg);
            }
            else
            {
                OfferImg dbOfferImg = context.OfferImgs.Where(o => o.OfferImgID == offerImg.OfferImgID).FirstOrDefault();
                if (dbOfferImg != null)
                {
                    if (dbOfferImg.ImgPath != offerImg.ImgPath)
                    {
                        changed = true;
                        pathToDelete = dbOfferImg.ImgPath;
                    }
                    dbOfferImg.ImgPath = offerImg.ImgPath;
                    dbOfferImg.Price = offerImg.Price;
                    dbOfferImg.BrandAndName = offerImg.BrandAndName;

                }
            }
            context.SaveChanges();
            if (changed)
            {
                return pathToDelete;
            }
            return "";
        }
        public OfferImg DeleteOfferImg(int id)
        {
            OfferImg offerImg = context.OfferImgs.Where(o => o.OfferImgID == id).FirstOrDefault();

            if (offerImg != null)
            {
                context.OfferImgs.Remove(offerImg);
                context.SaveChanges();
            }
            return offerImg;
        }
    }
}
