using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Concrete;
using DokoMobile.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Categories).Returns(new List<Category>
            {
                new Category {CategoryName = "Category 1"},
                new Category {CategoryName = "Category 2"},
            });

            kernel.Bind<IRepository>().To<EFRepository>();

        }
    }
}