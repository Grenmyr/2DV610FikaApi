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

         Mock<IFikaRepository> _fikaMock;
         Mock<IBakerRepository> _bakerMock;
         Service _fikaService;
         Service _bakerService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fikaMock = new Mock<IFikaRepository>();
            _bakerMock = new Mock<IBakerRepository>();
            _fikaService = new Service(_fikaMock.Object);
            _bakerService = new Service(_bakerMock.Object);
        }

        [TestMethod]
        public void ServiceGetFikasShouldInvokeRepositoryGetFikasOnce()
        {
            _fikaService.GetFikas();

            _fikaMock.Verify(fr => fr.GetFikas(), Times.Once);
        }

        [TestMethod]
        public void ServiceGetFikasReturnsExpectedFikaList()
        {
            List<Fika> emptyList = new List<Fika>();
            _fikaMock
                .Setup(repository => repository.GetFikas())
                .Returns(emptyList);

            List<Fika> result = _fikaService.GetFikas();
            Assert.AreSame(emptyList, result);
        }

        [TestMethod]
        public void ServiceGetBakersShouldInvokeRepositoryGetBakersOnce()
        {
            _bakerService.GetBakers();

            _bakerMock.Verify(s => s.GetBakers(), Times.Once);
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
            _bakerMock
                 .SetupSequence(repository => repository.GetBakers())
                 .Returns(expectedPopulatedList)
                 .Returns(expectedEmptyList);

            List<Baker> populatedResult = _bakerService.GetBakers();
            List<Baker> emptyResult = _bakerService.GetBakers();

            Assert.AreEqual(expectedPopulatedList.Count, populatedResult.Count);
            Assert.AreEqual(expectedEmptyList.Count, emptyResult.Count);
        }

        [TestMethod]
        public void ServiceGetBakersShouldNotReturnANullValue()
        {
            List<Baker> nullValue = (List<Baker>)null;
            List<Baker> expectedList = new List<Baker>();
            _bakerMock
                .Setup(repository => repository.GetBakers())
                .Returns(nullValue);

            List<Baker> result = _bakerService.GetBakers();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedList.Count, result.Count);
        }
    }
}
