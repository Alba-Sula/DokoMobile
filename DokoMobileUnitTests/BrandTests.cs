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
    public class BrandTests
    {
        [TestMethod]
        public void List_Contain_Brands()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(b => b.Brands).Returns(new Brands[]
            {
                new Brands{BrandId = 1, BrandName = "B1"},
                new Brands{BrandId = 2, BrandName = "B2"},
                new Brands{BrandId = 3, BrandName = "B3"},
            });
            BrandsController controller = new BrandsController(mock.Object);

            //---Act---
            var result = ((ViewResult)controller.List()).ViewData.Model as Brands[];

            //---Assert---
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0].BrandId);
            Assert.AreEqual(2, result[1].BrandId);
            Assert.AreEqual(3, result[2].BrandId);
        }

        [TestMethod]
        public void Can_Edit_Brand()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(b => b.Brands).Returns(new Brands[]
            {
                new Brands {BrandId = 1, BrandName = "B1"},
                new Brands {BrandId = 2, BrandName = "B2"},
                new Brands {BrandId = 3, BrandName = "B3"},
            });
            BrandsController controller = new BrandsController(mock.Object);

            //---Act---
            var brand1 = ((ViewResult)controller.Edit(1)).ViewData.Model as Brands;
            var brand2 = ((ViewResult)controller.Edit(2)).ViewData.Model as Brands;
            var brand3 = ((ViewResult)controller.Edit(3)).ViewData.Model as Brands;

            //---Assert---
            Assert.AreEqual(1, brand1.BrandId);
            Assert.AreEqual(2, brand2.BrandId);
            Assert.AreEqual(3, brand3.BrandId);
        }

        [TestMethod]
        public void Cannot_Edit_Value()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(b => b.Brands).Returns(new Brands[]
            {
                new Brands{BrandId = 1, BrandName="B1"}
            });
            BrandsController controller = new BrandsController(mock.Object);

            //---Act---
            var nonExistentBrand = ((ViewResult)controller.Edit(3)).ViewData.Model as Brands;

            //---Assert---
            Assert.IsNull(nonExistentBrand);
        }

        [TestMethod]
        public void Can_Save_Brand()
        {
            //---Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            BrandsController controller = new BrandsController(mock.Object);
            Brands brand = new Brands() { BrandName = "B2" };
            //---Act
            ActionResult result = controller.Edit(brand);

            //---Assert
            mock.Verify(b => b.SaveBrands(brand));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            //---Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(b => b.Brands).Returns(new Brands[]
            {
                new Brands(){BrandId = 1, BrandName = "B1"}
            });
            BrandsController controller = new BrandsController(mock.Object);
            Brands brand = new Brands() { BrandName = "Test" };
            controller.ModelState.AddModelError("error", "error");

            //---Act
            ActionResult result = controller.Edit(brand);


            //Assert
            mock.Verify(b => b.SaveBrands(It.IsAny<Brands>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod]
        public void Can_Delete_Brand()
        {
            //---Arrange
            Brands brand = new Brands() { BrandId = 2, BrandName = "B2" };
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(b => b.Brands).Returns(new Brands[]
            {
                new Brands(){BrandId = 1, BrandName = "B1"},
                brand
            });
            BrandsController controller = new BrandsController(mock.Object);

            //---Act
            ActionResult result = controller.Delete(brand.BrandId);

            //---Assert
            mock.Verify(b => b.DeleteBrand(brand.BrandId));
        }
    }
}
