using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using _2DV610FikaApi.Models;
using System.Web.Http.Results;
using System.Collections.Generic;
using _2DV610FikaApi.Models.Repositories;
using Moq;

namespace _2DV610FikaApi.Tests.Controllers
{
    [TestClass]
    public class BakerControllerTest
    {
        private Mock<IService> _service;
        private BakerController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new Mock<IService>();
            _controller = new BakerController();
        }

        [TestMethod]
        public void GetShouldReturnAnEmptyListOfBakers()
        {
            var allBakers = _controller.Get() as OkNegotiatedContentResult<List<Baker>>;
            
            Assert.AreEqual(0, allBakers.Content.Count);
        }

        [TestMethod]
        public void BakerGetActionShouldCallBakerServiceGetOnce()
        {
            Mock<IBakerRepository> mock = new Mock<IBakerRepository>();
            Service service = new Service(mock.Object);

            _controller.Get();

            mock.Verify(br => br.Get(), Times.Once);
        }
    }
}
