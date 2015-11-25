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

            IHttpActionResult result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<Fika>>));
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
            
            IHttpActionResult result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdShouldInvokeGetFikaByIdInService()
        {
            FikaController controller = new FikaController(_service.Object);

            controller.Get(88);

            _service.Verify((s => s.GetFika(88)),Times.Once);
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdParameterShouldReturnOkNegotiatedContentResultWithFika()
        {
            _service.Setup(s => s.GetFika(8888)).Returns(new Fika());
            FikaController controller = new FikaController(_service.Object);

            IHttpActionResult result = controller.Get(8888);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Fika>));
        }

        [TestMethod]
        public void FikaControllerGetWithIntIdParameterShouldReturnNotFoundifServiceReturnsNull()
        {
            Fika fika = null;
            _service.Setup(s => s.GetFika(8)).Returns(fika);
            FikaController controller = new FikaController(_service.Object);

            IHttpActionResult result = controller.Get(8);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
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
        public void FikaControllerPostShouldReturnBadRequestWhenModelStateIsNotValid()
        {
            Fika fika = new Fika();
            FikaController controller = new FikaController(_service.Object);
            controller.ModelState.AddModelError("", "an error");

            IHttpActionResult result = controller.Post(fika);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void FikaControllerDeleteShouldReturnOkResult()
        {
            FikaController controller = new FikaController(_service.Object);
            _service.Setup(s => s.DeleteFika(8888)).Returns(new Fika());
            IHttpActionResult result = controller.Delete(8888);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void FikaControllerDeleteShouldInvokeCallToServiceDeleteFika()
        {
            FikaController controller = new FikaController(_service.Object);

            controller.Delete(8888);

            _service.Verify(s => s.DeleteFika(8888),Times.Once);
        }

        [TestMethod]
        public void FikaControllerDeleteShouldReturnNotFoundIfServiceReturnsNull()
        {
            // Rule in service is if Fika returned is Null, It was not found.
            Fika fika = (Fika)null;
            FikaController controller = new FikaController(_service.Object);
            _service.Setup(s => s.DeleteFika(88)).Returns(fika);

            IHttpActionResult result = controller.Delete(88) ;

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void FikaControllerPutShouldReturnBadRequestWhenModelStateIsNotValid()
        {
            FikaController controller = new FikaController(_service.Object);
            controller.ModelState.AddModelError("", "an error");

            IHttpActionResult result = controller.Put(new Fika());

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void FikaControllerPutShouldInvokeServicePutFikas()
        {
            Fika fika = new Fika();
            FikaController controller = new FikaController(_service.Object);

            controller.Put(fika);

            _service.Verify(s => s.PutFika(fika), Times.Once);
        }

        [TestMethod]
        public void FikaControllerPutShouldOnSuccesfulPutReturnOkNegotiatedContentResultContaniningUpdatedFika()
        {
            Fika fika = new Fika();
            _service.Setup(s => s.PutFika(fika)).Returns(fika);
            FikaController controller = new FikaController(_service.Object);

            IHttpActionResult result = controller.Put(fika);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Fika>));
            Assert.ReferenceEquals(fika, result);
        }
        
    }
}
