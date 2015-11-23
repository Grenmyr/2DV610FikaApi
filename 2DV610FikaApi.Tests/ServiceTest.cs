using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models.Repositories;
using System.Collections.Generic;
using _2DV610FikaApi.Models;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ServiceShouldInvokeFikaRepositoryOnce()
        {
            Mock<IFikaRepository> mock = new Mock<IFikaRepository>();
            Service service = new Service(mock.Object);

            service.GetFikas();

            mock.Verify(fr => fr.GetFikas(), Times.Once);
        }

        [TestMethod]
        public void ServiceGetFikasReturnsExpectedFikaList()
        {
            List<Fika> emptyList = new List<Fika>();
            Mock<IFikaRepository> mock = new Mock<IFikaRepository>();
            Service service = new Service(mock.Object);
            mock
                .Setup(repository => repository.GetFikas())
                .Returns(emptyList);

            List<Fika> result = service.GetFikas();
            Assert.AreSame(emptyList, result);
        }
    }
}
