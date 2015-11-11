using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models.Repositories;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ShouldCallFikaRepositoryOnce()
        {
            Mock<IFikaRepository> mock = new Mock<IFikaRepository>();
            Service service = new Service(mock.Object);

            service.GetFikas();

            mock.Verify(fr => fr.GetFikas(), Times.Once);
        }
    }
}
