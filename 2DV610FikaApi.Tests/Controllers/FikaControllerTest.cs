using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using _2DV610FikaApi.Models.Repositories;
using System.Web.Http.Results;
using Moq;
using System.Collections.Generic;
using _2DV610FikaApi.Models;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class FikaControllerTest
    {
        private Mock<IFikaRepository> _repository;       
        private Mock<IService> _service;
        private FikaController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
           _repository = new Mock<IFikaRepository>();
           _service = new Mock<IService>();
           _controller = new FikaController();
        }

        [TestMethod]
        public void FikaControlllerGetShouldCallServiceGetFikasOnce()
        {
            _controller = new FikaController(_service.Object);

            _controller.Get();

            _service.Verify(s => s.GetFikas(), Times.Once);
        }

        [TestMethod]
        public void FikaControlllerGetShouldReturnOkNegotiatedContentResultContainingFikaList()
        {
            List<Fika> list = new List<Fika>();
            _service
                .Setup(service => service.GetFikas())
                .Returns(list);
            FikaController controller = new FikaController(_service.Object);

            OkNegotiatedContentResult<List<Fika>> result = controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(typeof (OkNegotiatedContentResult<List<Fika>>), result.GetType());
        }

        [TestMethod]
        public void FikaControllerShouldReturnFikaListWithTwoFikas()
        {
            List<Fika> list = new List<Fika>();
            list.Add(It.IsAny<Fika>());
            list.Add(It.IsAny<Fika>());
            _service.Setup(service => service.GetFikas()).Returns(list);
            FikaController _controller = new FikaController(_service.Object);

            OkNegotiatedContentResult<List<Fika>> result = _controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(2, result.Content.Count);
        }

        [TestMethod]
        public void FikaControllerShouldNotReturnOkNegotiatedContentResultWhenServiceGetFikasReturnsEmtyListOfFikas()
        {
            List<Fika> emtyList = null;
            _service
                .Setup(service => service.GetFikas())
                .Returns(emtyList);

            FikaController _controller = new FikaController(_service.Object);
            var result =_controller.Get() as dynamic;

            Assert.AreNotEqual(typeof(OkNegotiatedContentResult<List<Fika>>), result.GetType());
        }
    }
}
