using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using _2DV610FikaApi.Models.Repositories;
using System.Web.Http.Results;
using Moq;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class FikaControllerTest
    {
        private Mock<IFikaRepository> _repository;
        private FikaController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IFikaRepository>();
            Mock<IService> _service = new Mock<IService>();
            _controller = new FikaController(_service.Object);
        }

        [TestMethod]
        public void  ShouldReturnString()
        {
            //IHttpActionResult actionResult = _controller.Get();

            //var result = actionResult as OkNegotiatedContentResult<String>;
            //Assert.AreEqual("test", result.Content);
        }

        [TestMethod]
        public void FikaControlllerGetShouldCallServiceGetFikasOnce()
        {
            Mock<IService> service = new Mock<IService>();
            _controller.Get();

            service.Verify(c => c.GetFikas(), Times.Once);
        }
    }
}
