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
        private Mock<IBakerRepository> _bakerRepository;
        private IService _service;
        private BakerController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _bakerRepository = new Mock<IBakerRepository>();
            _service = new Service(_bakerRepository.Object);
            _controller = new BakerController(_service);
        }

        [TestMethod]
        public void GetShouldReturnAnEmptyListOfBakers()
        {
            var allBakers = _controller.Get() as OkNegotiatedContentResult<List<Baker>>;
            
            Assert.AreEqual(0, allBakers.Content.Count);
        }

        [TestMethod]
        public void BakerControllerGetActionShouldInvokeBakerServiceGetBakersOnce()
        {
            _controller.Get();

            _bakerRepository.Verify(br => br.GetBakers(), Times.Once);
        }
    }
}
