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
        private FikaController _controller;
        Mock<IService> _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IFikaRepository>();
            _service = new Mock<IService>();
            _controller = new FikaController(_service.Object);
        }

        [TestMethod]
        public void FikaControlllerGetShouldCallServiceGetFikasOnce()
        {
            _controller.Get();

            _service.Verify(c => c.GetFikas(), Times.Once);
        }

        [TestMethod]
        public void FikaControlllerGetshouldreturnStatusCode200()
        {
            var result = _controller.Get();

            Assert.AreEqual(typeof(OkResult), result.GetType());
        }

        [TestMethod]
        public void FikaControlllerGetshouldreturAResponseWithAListOfTypeFika()
        {
            OkNegotiatedContentResult<List<Fika>> result = _controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(typeof(List<Fika>), result.Content.GetType());
        }
    }
}
