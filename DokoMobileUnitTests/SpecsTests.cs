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
    public class SpecsTests
    {
        [TestMethod]
        public void List_Contain_Specs()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs (){SpecsId = 1, Batery = 2 , Display = "Good", OS = "OS", Processor = "Processor", RAM = "RAM"},
                new Specs (){SpecsId = 2, Batery = 2 , Display = "Good", OS = "OS", Processor = "Processor", RAM = "RAM"},
            });
            SpecsController controller = new SpecsController(mock.Object);


            var result = ((ViewResult)controller.List()).ViewData.Model as Specs[];


            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(1, result[0].SpecsId);
            Assert.AreEqual(2, result[1].SpecsId);
        }

        [TestMethod]
        public void Can_Edit_Specs()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs(){SpecsId = 1, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM="asass"},
            });
            SpecsController controller = new SpecsController(mock.Object);


            var result = ((ViewResult)controller.Edit(1)).ViewData.Model as Specs;

            Assert.AreEqual(1, result.SpecsId);

        }

        [TestMethod]
        public void Cannot_Edit_NonExistent()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs(){SpecsId = 1, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM="asass"},
            });
            SpecsController controller = new SpecsController(mock.Object);

            var result = ((ViewResult)controller.Edit(7)).ViewData.Model as Specs;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Values()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs(){SpecsId = 1, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM="asass"},
            });
            SpecsController controller = new SpecsController(mock.Object);
            Specs specs = new Specs() { SpecsId = 2, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM = "asass" };

            ActionResult result = controller.Edit(specs);

            mock.Verify(s => s.SaveSpecs(specs));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Wrong_Value()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs(){SpecsId = 1, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM="asass"},
                new Specs() { SpecsId = 2, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM = "asass" },
            });
            SpecsController controller = new SpecsController(mock.Object);
            Specs specs = new Specs() { SpecsId = 3, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM = "asass" };
            controller.ModelState.AddModelError("error", "error");

            ActionResult result = controller.Edit(specs);

            mock.Verify(s => s.SaveSpecs(It.IsAny<Specs>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_Specs()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(s => s.Specs).Returns(new Specs[]
            {
                new Specs(){SpecsId = 1, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM="asass"},
                new Specs() { SpecsId = 2, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM = "asass" },
            });
            SpecsController controller = new SpecsController(mock.Object);
            Specs specs = new Specs() { SpecsId = 3, OS = "sdsd", Batery = 2, Display = "dsd", Processor = "ppp", RAM = "asass" };

            controller.Delete(specs.SpecsId);

            mock.Verify(s => s.DeleteSpecs(specs.SpecsId));
        }

    }
}
