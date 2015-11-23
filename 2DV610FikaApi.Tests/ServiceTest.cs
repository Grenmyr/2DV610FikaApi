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
        public void ServiceGetFikasShouldInvokeRepositoryGetFikasOnce()
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

        [TestMethod]
        public void ServiceGetBakersShouldInvokeRepositoryGetBakersOnce()
        {
            Mock<IBakerRepository> mock = new Mock<IBakerRepository>();
            Service service = new Service(mock.Object);

            service.GetBakers();

            mock.Verify(s => s.GetBakers(), Times.Once);
        }

        [TestMethod]
        public void ServiceGetBakersShouldReturnExpectedBakerList()
        {
            List<Baker> expectedPopulatedList = new List<Baker>
            {
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>()
            };

            List<Baker> expectedEmptyList = new List<Baker>();

            Mock<IBakerRepository> mock = new Mock<IBakerRepository>();
            Service service = new Service(mock.Object);
            mock
                .SetupSequence(repository => repository.GetBakers())
                .Returns(expectedPopulatedList)
                .Returns(expectedEmptyList);

            List<Baker> populatedResult = service.GetBakers();
            List<Baker> emptyResult = service.GetBakers();

            Assert.AreEqual(expectedPopulatedList.Count, populatedResult.Count);
            Assert.AreEqual(expectedEmptyList.Count, emptyResult.Count);
        }
    }
}
