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
        Mock<IService> _service;
        BakerController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new Mock<IService>();
            _controller = new BakerController(_service.Object);
        }

        [TestMethod]
        public void BakerServiceGetBakersShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            _controller.Get();

            _service.Verify(br => br.GetBakers(), Times.Once);
        }

        [TestMethod]
        public void BakerControllerGetActionShouldReturnAListAsContentWithCorrectAmountOfBakers()
        {
            List<Baker> expectedBakerList = new List<Baker>
            {
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>()
            };

            _service
                .Setup(s => s.GetBakers())
                .Returns(expectedBakerList);

            dynamic result = _controller.Get() as OkNegotiatedContentResult<List<Baker>>;

            Assert.AreEqual(expectedBakerList.Count, result.Content.Count);
            Assert.IsInstanceOfType(result.Content, typeof(List<Baker>));
        }

        [TestMethod]
        public void BakerControllerGetBakerActionShouldReturnABakerAsContentForExistingIdAndStatusCodeOk()
        {
            int existingBakerId = 25;
            Baker expectedBaker = new Baker("David", "david.grenmyr@gmail.com");
            _service
                .Setup(service => service.GetBaker(existingBakerId))
                .Returns(expectedBaker);

            var baker = _controller.Get(existingBakerId) as OkNegotiatedContentResult<Baker>;

            // Assert that status code is 200 Ok
            Assert.IsNotNull(baker);
            Assert.IsNotNull(baker.Content);
            Assert.IsInstanceOfType(baker.Content, typeof(Baker));
        }

        [TestMethod]
        public void BakerControllerGetBakerActionShouldReturnStatusCodeNotFoundForNonExistingId()
        {
            int nonExistingId = 42;
            _service
                .Setup(service => service.GetBaker(nonExistingId))
                .Returns((Baker) null);

            IHttpActionResult result = _controller.Get(nonExistingId);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BakerServicePostBakerShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            Baker bakerToAdd = new Baker("Erik", "erik.magnusson@mail.com");

            _controller.Post(bakerToAdd);

            _service
                .Verify(service => service.AddBaker(bakerToAdd), Times.Once);
        }

        [TestMethod]
        public void BakerControllerPostActionShouldReturnPostedBakerAsContentAndStatusCodeCreatedIfCreateIsSuccessful()
        {
            Baker bakerToAdd = new Baker("Andreas", "andreas.fridlund@mail.com");
            _service
                .Setup(service => service.AddBaker(bakerToAdd))
                .Returns(bakerToAdd);

            var baker = _controller.Post(bakerToAdd) as CreatedAtRouteNegotiatedContentResult<Baker>;

            Assert.IsNotNull(baker);
            Assert.IsNotNull(baker.Content);
            //TODO: Break out validation of data to two seperate tests.
            Assert.AreSame(baker.Content, bakerToAdd);
            Assert.AreEqual(baker.Content.Email, bakerToAdd.Email);
        }

        [TestMethod]
        public void BakerControllerPostShouldReturnBadRequestIfModelStateIsNotValid()
        {
            Baker baker = new Baker("Andreas", "andreas.fridlund@mail.com");
            _controller.ModelState.AddModelError("", "an error");

            IHttpActionResult result = _controller.Post(baker);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void BakerControllerPutShouldReturnBadRequestIfModelStateIsNotValid()
        {
            Baker baker = new Baker("Andreas", "andreas.fridlund@mail.com");
            _controller.ModelState.AddModelError("", "Error");

            IHttpActionResult result = _controller.Put(baker);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public void BakerServiceDeleteBakerShouldBeInvokedOnceWhenBakerControllerDeleteActionIsCalled()
        {
            _controller.Delete(It.IsAny<int>());

            _service
                .Verify(service => service.DeleteBaker(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void BakerControllerActionDeleteReturnsStatusCodeOkIfBakerToDeleteExists()
        {
            int existingId = 1;
            Baker existingBaker = new Baker("Erik", "erik.magnusson@email.com");
            _service
                .Setup(service => service.DeleteBaker(existingId))
                .Returns(existingBaker);

            IHttpActionResult result = _controller.Delete(existingId);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void BakerControllerActionDeleteReturnsNotFoundOnNonExistingBaker()
        {
            int existingId = 1;
            int nonExistingId = 2;
            Baker existingBaker = new Baker("Erik", "erik.magnusson@email.com");
            _service
                .Setup(service => service.DeleteBaker(existingId))
                .Returns(existingBaker);

            IHttpActionResult result = _controller.Delete(nonExistingId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
