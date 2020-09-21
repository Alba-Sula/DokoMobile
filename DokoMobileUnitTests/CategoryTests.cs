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
    public class CategoryTests
    {

        [TestMethod]
        public void List_Contain_Categories()
        {
            //---Arrange---creating a mock repository
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Categories).Returns(new Category[]
            {
                new Category{CategoryId = 1,CategoryName="Category 1"},
                new Category{CategoryId = 2,CategoryName="Category 2"},
                new Category{CategoryId = 3,CategoryName="Category 3"},
                new Category{CategoryId = 4,CategoryName="Category 4"},
            });

            //---Arrange---creating a controller
            CategoriesController categoriesController = new CategoriesController(mock.Object);


            //---Action---
            var result = categoriesController.List();
            var categories = ((ViewResult)result).ViewData.Model as Category[];


            //---Assert---
            Assert.AreEqual(categories.Length, 4);
            Assert.AreEqual("Category 1", categories[0].CategoryName);
            Assert.AreEqual("Category 2", categories[1].CategoryName);
            Assert.AreEqual("Category 3", categories[2].CategoryName);
            Assert.AreEqual("Category 4", categories[3].CategoryName);

        }

        [TestMethod]
        public void Can_Edit_Category()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Categories).Returns(new Category[]
            {
                new Category{CategoryId = 1,CategoryName="Category 1"},
                new Category{CategoryId = 2,CategoryName="Category 2"},
                new Category{CategoryId = 3,CategoryName="Category 3"},
                new Category{CategoryId = 4,CategoryName="Category 4"},
            });

            //---Arrange---
            CategoriesController categoriesController = new CategoriesController(mock.Object);

            //---Action---
            var category1 = ((ViewResult)categoriesController.Edit(1)).ViewData.Model as Category;
            var category2 = ((ViewResult)categoriesController.Edit(2)).ViewData.Model as Category;
            var category3 = ((ViewResult)categoriesController.Edit(3)).ViewData.Model as Category;
            var category4 = ((ViewResult)categoriesController.Edit(4)).ViewData.Model as Category;

            //---Assert---
            Assert.AreEqual(1, category1.CategoryId);
            Assert.AreEqual(2, category2.CategoryId);
            Assert.AreEqual(3, category3.CategoryId);
            Assert.AreEqual(4, category4.CategoryId);
        }

        [TestMethod]
        public void Can_Edit_NonExistent_Category()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(c => c.Categories).Returns(new Category[]
            {
                new Category {CategoryId = 1 , CategoryName ="Category1"},
                new Category {CategoryId = 2 , CategoryName ="Category2"},
            });

            CategoriesController categoriesController = new CategoriesController(mock.Object);

            //---Action---

            var nonexistentCategory = ((ViewResult)categoriesController.Edit(5)).ViewData.Model as Category;


            //---Assert---

            Assert.IsNull(nonexistentCategory);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            CategoriesController categoriesController = new CategoriesController(mock.Object);
            Category category = new Category() { CategoryName = "Category Test Edit" };

            //---Act---
            ActionResult result = categoriesController.Edit(category);

            //---Assert---
            mock.Verify(m => m.SaveCategory(category));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CanNot_Save_Invalid_Changes()
        {
            //---Arrange---
            Mock<IRepository> mock = new Mock<IRepository>();
            CategoriesController categoriesController = new CategoriesController(mock.Object);
            Category category = new Category { CategoryName = "Test" };
            categoriesController.ModelState.AddModelError("error", "error");

            //---Act---
            ActionResult result = categoriesController.Edit(category);

            //---Assert---
            mock.Verify(m => m.SaveCategory(It.IsAny<Category>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Category()
        {
            //---Arrange---
            Category categoryToDelete = new Category { CategoryId = 4, CategoryName = "C4" };
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Categories).Returns(new Category[]
            {
                new Category{CategoryId = 1, CategoryName ="C1"},
                new Category{CategoryId = 2, CategoryName ="C2"},
                new Category{CategoryId = 3, CategoryName ="C3"},
                categoryToDelete,
            });
            CategoriesController categoriesController = new CategoriesController(mock.Object);

            //---Act---
            categoriesController.Delete(categoryToDelete.CategoryId);

            //---Assert---
            mock.Verify(m => m.DeleteCategory(categoryToDelete.CategoryId));

        }

    }
}
