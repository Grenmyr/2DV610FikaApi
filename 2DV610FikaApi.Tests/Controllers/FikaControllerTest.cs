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
        public void FikaControlllerGetshouldreturnStatusCode200()
        {
            /* TODO: Have not figured out how to extract Statuscode 200 from this test.
            // Testing the route with postman clearly indicate it return a 200, but how to abstract
            // an 200 statuscode from this test is at the moement to hard for me. 
             * The type OkNegotiatedContentResult is basicly a 200 response + data.
             * 
             Test pass now, but it test more then just the statuscode and it annoyes me.*/
            OkNegotiatedContentResult<List<Fika>> result = _controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(typeof (OkNegotiatedContentResult<List<Fika>>), result.GetType());
        }

        [TestMethod]
        public void FikaControlllerGetshouldreturAResponseWithAListOfTypeFika()
        {
            OkNegotiatedContentResult<List<Fika>> result = _controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(typeof(List<Fika>), result.Content.GetType());
        }

        [TestMethod]
        public void FikaControllerShouldReturnAFikaListWithTwoFikas()
        {
            List<Fika> list = new List<Fika>();
            list.Add(new Fika());
            list.Add(new Fika());
            _repository.Setup(r => r.GetFikas()).Returns(list);
            Service serviceStub = new Service(_repository.Object);
            FikaController _controller = new FikaController(serviceStub);


            OkNegotiatedContentResult<List<Fika>> result = _controller.Get() as OkNegotiatedContentResult<List<Fika>>;

            Assert.AreEqual(2, result.Content.Count);

        }
    }
}
