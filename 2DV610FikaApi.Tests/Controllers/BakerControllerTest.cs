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

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new Mock<IService>();
        }

        [TestMethod]
        public void BakerServiceGetBakersShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            BakerController controller = new BakerController(_service.Object);

            controller.Get();

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

            BakerController controller = new BakerController(_service.Object);

            dynamic result = controller.Get() as OkNegotiatedContentResult<List<Baker>>;

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
            BakerController bakerController = new BakerController(_service.Object);

            var baker = bakerController.Get(existingBakerId) as OkNegotiatedContentResult<Baker>;

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

            BakerController bakerController = new BakerController(_service.Object);

            IHttpActionResult result = bakerController.Get(nonExistingId);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BakerServicePostBakerShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            Baker bakerToAdd = new Baker("Erik", "erik.magnusson@mail.com");
            BakerController bakerController = new BakerController(_service.Object);

            bakerController.Post(bakerToAdd);

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
            var controller = new BakerController(_service.Object);
            
            var baker = controller.Post(bakerToAdd) as CreatedAtRouteNegotiatedContentResult<Baker>;

            Assert.IsNotNull(baker);
            Assert.IsNotNull(baker.Content);
            //TODO: Break out validation of data to two seperate tests.
            Assert.AreSame(baker.Content, bakerToAdd);
            Assert.AreEqual(baker.Content.Email, bakerToAdd.Email);
        }
    }
}
