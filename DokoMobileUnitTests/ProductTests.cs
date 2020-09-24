using System;
using System.Web.Mvc;
using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using DokoMobile.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DokoMobileUnitTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Can_Get_Products()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(p => p.Products).Returns(new Product[]
            {
                new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2,},
            });
            ProductsController controller = new ProductsController(mock.Object);


            var result = ((ViewResult)controller.List()).ViewData.Model as Product[];

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0].ProductId);

        }

        [TestMethod]
        public void Can_Edit_Category()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                 new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 2, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 3, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
            });

            //---Arrange---
            ProductsController controller = new ProductsController(mock.Object);

            //---Action---
            var product1 = ((ViewResult)controller.Edit(1)).ViewData.Model as Product;
            var product2 = ((ViewResult)controller.Edit(2)).ViewData.Model as Product;
            var product3 = ((ViewResult)controller.Edit(3)).ViewData.Model as Product;

            //---Assert---
            Assert.AreEqual(1, product1.ProductId);
            Assert.AreEqual(2, product2.ProductId);
            Assert.AreEqual(3, product3.ProductId);
        }

        [TestMethod]
        public void Can_Edit_NonExistent_Category()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                 new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 2, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 3, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
            });
            ProductsController controller = new ProductsController(mock.Object);
            //---Action---

            var nonexistent = ((ViewResult)controller.Edit(5)).ViewData.Model as Product;


            //---Assert---

            Assert.IsNull(nonexistent);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                 new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 2, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 3, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
            });
            ProductsController controller = new ProductsController(mock.Object);
            Product product = new Product() { ProductId = 4, Name = "Alba", BrandId = 1, CategoryId = 1, Color = "Blue", ProductCondition = "Very good", Description = "Desc", Price = 23.2, };

            //---Act---
            ActionResult result = controller.Edit(product.ProductId);

            //---Assert---
            mock.Verify(m => m.SaveProducts(product));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CanNot_Save_Invalid_Changes()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                 new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 2, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2,},
                 new Product(){ProductId = 3, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
            });
            ProductsController controller = new ProductsController(mock.Object);
            Product product = new Product() { ProductId = 4, Name = "Alba", BrandId = 1, CategoryId = 1, Color = "Blue", ProductCondition = "Very good", Description = "Desc", Price = 23.2,};
            controller.ModelState.AddModelError("error", "error");

            //---Act---
            ActionResult result = controller.Edit(product.ProductId);

            //---Assert---
            mock.Verify(m => m.SaveProducts(It.IsAny<Product>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Category()
        {
            //---Arrange---
            Product product = new Product() { ProductId = 4, Name = "Alba", BrandId = 1, CategoryId = 1, Color = "Blue", ProductCondition = "Very good", Description = "Desc", Price = 23.2,  };
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Products).Returns(new Product[]
            {
                 new Product(){ProductId = 1, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2,},
                 new Product(){ProductId = 2, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 new Product(){ProductId = 3, Name = "Alba", BrandId = 1, CategoryId = 1, Color="Blue",ProductCondition="Very good", Description="Desc", Price = 23.2, },
                 product
            });
            ProductsController controller = new ProductsController(mock.Object);

            //---Act---
            controller.Delete(product.ProductId);

            //---Assert---
            mock.Verify(m => m.DeleteProduct(product.ProductId));

        }

    }
}
