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


        [TestInitialize]
        public void TestInitialize()
        {
           _repository = new Mock<IFikaRepository>();
           _service = new Mock<IService>();
        }

        [TestMethod]
        public void FikaControlllerGetShouldCallServiceGetFikasOnce()
        {
            FikaController controller = new FikaController(_service.Object);

            controller.Get();

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
        public void FikaControllerShouldReturnNotFoundResultWhenServiceGetFikasReturnsEmtyListOfFikas()
        {
            List<Fika> nullList = null;
            _service
                .Setup(service => service.GetFikas())
                .Returns(nullList);

            FikaController controller = new FikaController(_service.Object);
            NotFoundResult result = controller.Get() as NotFoundResult;

            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdShouldInvokeGetFikaByIdInService()
        {
            FikaController controller = new FikaController(_service.Object);

            controller.Get(88);

            _service.Verify((s => s.GetFikaById(88)),Times.Once);
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdParameterShouldReturnOkNegotiatedContentResultWithFika()
        {
            _service.Setup(s => s.GetFikaById(8888)).Returns(new Fika());
            FikaController controller = new FikaController(_service.Object);

            OkNegotiatedContentResult<Fika> result = controller.Get(8888) as OkNegotiatedContentResult<Fika>;

            Assert.AreEqual(typeof(OkNegotiatedContentResult<Fika>), result.GetType());
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdParameterShouldReturnNotFoundifServiceReturnsNull()
        {
            Fika fika = null;
            _service.Setup(s => s.GetFikaById(8)).Returns(fika);
            FikaController controller = new FikaController(_service.Object);

            NotFoundResult result = controller.Get(8) as NotFoundResult;

            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public void FikaControllerPostShouldInvokeCallToServiceAddFika()
        {
            Fika fika = new Fika();
            FikaController controller = new FikaController(_service.Object);
            
            controller.Post(fika);

            _service.Verify(s => s.AddFika(fika), Times.Once);
        }

        [TestMethod]
        public void FikaControllerPostshouldReturnCreatedAtRouteNegotiatedContentResultOnSuccesfulPost()
        {
            Fika fika = new Fika();
            fika.Date = new DateTime();
            fika.Pastry = "NewPastry";

            _service.Setup(s => s.AddFika(fika)).Returns(fika);
            FikaController controller = new FikaController(_service.Object);


            CreatedAtRouteNegotiatedContentResult<Fika> result = controller.Post(fika) as CreatedAtRouteNegotiatedContentResult<Fika>;

            Assert.AreEqual(fika, result.Content);
        }

        [TestMethod]
        public void FikaControllerShouldReturnBadRequestWhenModelStateIsNotValid()
        {
            Fika fikaWithIllegalPastryProperty = new Fika();
            FikaController controller = new FikaController(_service.Object);

            BadRequestResult result = controller.Post(fikaWithIllegalPastryProperty) as BadRequestResult;

            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }
    
    }
}
