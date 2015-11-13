﻿using System;
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
        public void BakerRepositoryGetBakersShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            _controller.Get();

            _bakerRepository.Verify(br => br.GetBakers(), Times.Once);
        }

        [TestMethod]
        public void BakerControllerGetActionShouldReturnAListAsContentWithCorrectAmountOfBakers()
        {
            var expectedBakerList = new List<Baker>
            {
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>()
            };

            var service = new Mock<IService>();
            service
                .Setup(s => s.GetBakers())
                .Returns(expectedBakerList);

            var controller = new BakerController(service.Object);

            dynamic result = controller.Get() as OkNegotiatedContentResult<List<Baker>>;

            Assert.AreEqual(expectedBakerList.Count, result.Content.Count);
            Assert.IsInstanceOfType(result.Content, typeof(List<Baker>));
        }

        [TestMethod]
        public void BakerControllerGetBakerActionShouldReturnABakerAsContentForExistingIdAndStatusCodeOk()
        {
            int existingBakerId = 25;
            var expectedBaker = new Baker("David", "david.grenmyr@gmail.com");
            _bakerRepository
                .Setup(bakerRepository => bakerRepository.GetBaker(existingBakerId))
                .Returns(expectedBaker);
            var service = new Service(_bakerRepository.Object);
            var bakerController = new BakerController(service);

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
            _bakerRepository
                .Setup(bakerRepository => bakerRepository.GetBaker(nonExistingId))
                .Returns((Baker) null);

            var service = new Service(_bakerRepository.Object);
            var bakerController = new BakerController(service);

            IHttpActionResult result = bakerController.Get(nonExistingId);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void BakerRepositoryPostBakerShouldBeInvokedOnceWhenBakerControllerGetActionIsCalled()
        {
            var bakerToAdd = new Baker("Erik", "erik.magnusson@mail.com");
            _controller.Post(bakerToAdd);
            _bakerRepository
                .Verify(bakerRepository => bakerRepository.AddBaker(It.IsAny<Baker>()));
        }

        [TestMethod]
        public void BakerControllerPostActionShouldReturnPostedBakerAsContentAndStatusCodeCreatedIfCreateIsSuccessful()
        {
            var bakerToAdd = new Baker("Andreas", "andreas.fridlund@mail.com");
            var service = new Service(_bakerRepository.Object);
            var controller = new BakerController(service);
            _bakerRepository
                .Setup(bakerRepository => bakerRepository.AddBaker(bakerToAdd))
                .Returns(bakerToAdd);

            var baker = controller.Post(bakerToAdd) as CreatedAtRouteNegotiatedContentResult<Baker>;

            Assert.IsNotNull(baker);
            Assert.IsNotNull(baker.Content);
            Assert.IsInstanceOfType(baker.Content, typeof(Baker));

        }
    }
}
