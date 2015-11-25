using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models.Repositories;
using System.Collections.Generic;
using _2DV610FikaApi.Models;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class ServiceTest
    {

         Mock<IFikaRepository> _fikaMock;
         Mock<IBakerRepository> _bakerMock;
         Service _fikaService;
         Service _bakerService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fikaMock = new Mock<IFikaRepository>();
            _bakerMock = new Mock<IBakerRepository>();
            _fikaService = new Service(_fikaMock.Object);
            _bakerService = new Service(_bakerMock.Object);
        }

        [TestMethod]
        public void ServiceGetFikasShouldInvokeRepositoryGetFikasOnce()
        {
            _fikaService.GetFikas();

            _fikaMock.Verify(fr => fr.GetFikas(), Times.Once);
        }

        [TestMethod]
        public void ServiceGetFikasReturnsExpectedFikaList()
        {
            List<Fika> emptyList = new List<Fika>();
            _fikaMock
                .Setup(repository => repository.GetFikas())
                .Returns(emptyList);

            List<Fika> result = _fikaService.GetFikas();
            Assert.AreSame(emptyList, result);
        }

        [TestMethod]
        public void ServiceGetBakersShouldInvokeRepositoryGetBakersOnce()
        {
            _bakerService.GetBakers();

            _bakerMock.Verify(s => s.GetBakers(), Times.Once);
        }

        [TestMethod]
        public void ServiceGetBakersShouldReturnExpectedBakerList()
        {
            List<Baker> expectedPopulatedList = new List<Baker>
            {
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>(),
                It.IsAny<Baker>()
            };
            List<Baker> expectedEmptyList = new List<Baker>();
            _bakerMock
                 .SetupSequence(repository => repository.GetBakers())
                 .Returns(expectedPopulatedList)
                 .Returns(expectedEmptyList);

            List<Baker> populatedResult = _bakerService.GetBakers();
            List<Baker> emptyResult = _bakerService.GetBakers();

            Assert.AreEqual(expectedPopulatedList.Count, populatedResult.Count);
            Assert.AreEqual(expectedEmptyList.Count, emptyResult.Count);
        }

        [TestMethod]
        public void ServiceGetBakersShouldNotReturnANullValue()
        {
            List<Baker> nullValue = (List<Baker>)null;
            List<Baker> expectedList = new List<Baker>();
            _bakerMock
                .Setup(repository => repository.GetBakers())
                .Returns(nullValue);

            List<Baker> result = _bakerService.GetBakers();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedList.Count, result.Count);
        }

        [TestMethod]
        public void ServiceGetBakerMethodShouldInvokeRepositoryGetBakerOnce()
        {
            _bakerService.GetBaker(It.IsAny<int>());

            _bakerMock.Verify(bakerRepository => bakerRepository.GetBaker(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ServiceGetBakerMethodShouldReturnBakerForExistingId()
        {
            int existingBakerId = 20;
            Baker expectedBaker = new Baker("David", "david.grenmyr@gmail.com");
            _bakerMock
                .Setup(service => service.GetBaker(existingBakerId))
                .Returns(expectedBaker);

            var baker = _bakerService.GetBaker(existingBakerId);

            Assert.AreSame(expectedBaker, baker);
        }

        [TestMethod]
        public void ServiceGetBakerMethodShouldReturnNullForNonExistingId()
        {
            int nonExistingId = 15;
            Baker expectedBaker = null;
            _bakerMock
                .Setup(service => service.GetBaker(nonExistingId))
                .Returns((Baker)null);

            var baker = _bakerService.GetBaker(nonExistingId);

            Assert.AreSame(expectedBaker, baker);
        }

        [TestMethod]
        public void ServiceAddBakerShouldInvokeRepositoryPostBakerOnce()
        {
            _bakerService.AddBaker(It.IsAny<Baker>());

            _bakerMock.Verify(bakerRepository => bakerRepository.AddBaker(It.IsAny<Baker>()), Times.Once);
        }

        [TestMethod]
        public void ServiceAddBakerShouldReturnABaker()
        {
            Baker bakerToAdd = new Baker("Andreas", "andreas.fridlund@mail.com");
            _bakerMock
                .Setup(bakerRepository => bakerRepository.AddBaker(bakerToAdd))
                .Returns(bakerToAdd);

            Baker result = _bakerService.AddBaker(bakerToAdd);

            Assert.AreSame(bakerToAdd, result);
        }

        [TestMethod]
        public void ServiceDeleteBakerMethodReturnsBakerForExistingId()
        {
            int existingId = 1;
            Baker expectedBaker = new Baker("Erik", "erik.magnusson@email.com");
            expectedBaker.Id = existingId;
            _bakerMock
                .Setup(bakerRepository => bakerRepository.GetBaker(existingId))
                .Returns(expectedBaker);

            Baker baker = _bakerService.DeleteBaker(existingId);

            Assert.AreSame(expectedBaker, baker);
        }

        [TestMethod]
        public void ServiceDeleteBakerMethodReturnsNullForNonExistingId()
        {
            int existingId = 1;
            int nonExistingId = 2;
            Baker existingBaker = new Baker("Erik", "erik.magnusson@email.com");
            existingBaker.Id = existingId;
            _bakerMock
                .Setup(bakerRepository => bakerRepository.GetBaker(existingId))
                .Returns(existingBaker);

            Baker baker = _bakerService.DeleteBaker(nonExistingId);

            Assert.IsNull(baker);
            Assert.AreNotSame(existingBaker, baker);
        }

        [TestMethod]
        public void BakerRepositoryDeleteBakerShouldBeInvokedOnceWhenBakerServiceDeleteMethodIsCalled()
        {
            int existingId = 1;
            Baker existingBaker = new Baker("Erik", "erik.magnusson@email.com");
            existingBaker.Id = existingId;

            _bakerMock
            .Setup(bakerRepository => bakerRepository.GetBaker(existingId))
            .Returns(existingBaker);

            _bakerService.DeleteBaker(existingId);

            _bakerMock.Verify(bakerRepository => bakerRepository.DeleteBaker(existingBaker), Times.Once);
        }

        [TestMethod]
        public void BakerRepositoryPutMethodShouldBeInvokedOnceWhenBakerServicePutMethodIsCalled()
        {
            int existingId = 1;
            Baker existingBaker = new Baker("Andreas", "andreas.fridlund@mail.com");
            existingBaker.Id = existingId;

            _bakerMock
                .Setup(bakerRepository => bakerRepository.GetBaker(existingId))
                .Returns(existingBaker);

            _bakerService.PutBaker(existingId);

            _bakerMock.Verify(bakerRepository => bakerRepository.PutBaker(existingBaker), Times.Once);
        }

        [TestMethod]
        public void ServicePutBakerMethodShouldReturnBakerForExistingId()
        {
            int existingId = 1;
            Baker existingBaker = new Baker("Andreas", "andreas.fridlund@mail.com");
            Baker updatedBaker = new Baker("Andreas Fridlund", "andreas.fridlund@mail.com");
            existingBaker.Id = existingId;
            _bakerMock
                .Setup(bakerRepository => bakerRepository.GetBaker(existingId))
                .Returns(existingBaker);

            _bakerMock
                .Setup(bakerRepository => bakerRepository.PutBaker(existingBaker))
                .Returns(updatedBaker);

            Baker baker = _bakerService.PutBaker(existingId);

            Assert.AreSame(updatedBaker, baker);
        }
        [TestMethod]
        public void ServiceGetFikahouldInvokeRespoistoryGetFikaOnceAndReturnsTheMockedFika()
        {
            Fika fika = new Fika();
            fika.Pastry = "Drömmar";
            _fikaMock.Setup(fm => fm.GetFika(55)).Returns(fika);
            
            Fika result = _fikaService.GetFika(55);
             
            _fikaMock.Verify(fr => fr.GetFika(55), Times.Once);
            Assert.AreEqual(fika.Pastry,result.Pastry );      
        }

        [TestMethod]
        public void ServiceAddFikaShouldInvokeRepositoryAddFikaOnce()
        {
            _fikaService.AddFika(It.IsAny<Fika>());

            _fikaMock.Verify(fm => fm.AddFika(It.IsAny<Fika>()), Times.Once);
        }

        [TestMethod]
        public void ServiceAddFikaShouldReturnTheSameFika()
        {
            Fika fika = new Fika()
                {
                    Pastry = "drömmar",
                    Date = DateTime.Today,
                    Id = 8888
                };

            _fikaMock
                .Setup(fm => fm.AddFika(fika))
                .Returns(fika);

            Fika result = _fikaService.AddFika(fika);

            Assert.AreEqual("drömmar", result.Pastry);
            Assert.AreEqual(8888, result.Id);
            Assert.AreEqual(DateTime.Today.Day, result.Date.Day);
        }

        [TestMethod]
        public void ServiceDeleteFikaShouldInvokeFikaRepositoryGetFikaOnce()
        {
            _fikaService.DeleteFika(8888);

            _fikaMock.Verify(fm => fm.GetFika(8888), Times.Once);
        }

        [TestMethod]
        public void ServiceDeleteFikaShouldReturnTheDeletedBakerIfBakerWIthThatIdExist()
        {
            Fika fika = new Fika();
            _fikaMock.Setup(fm => fm.GetFika(8888)).Returns(fika);

            Fika result = _fikaService.DeleteFika(8888);

            Assert.AreSame(fika, result);
        }

        [TestMethod]
        public void ServiceDeleteFikaShouldReturnNullWhenNoFikaWithInvokedIdExist()
        {
            Fika fika = new Fika();
            _fikaMock.Setup(fm => fm.GetFika(6666)).Returns(fika);

            Fika result = _fikaService.DeleteFika(8888);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ServiceDeleteFikaShouldInvokeFikaRepositoryDeleteFikaOnceAndItReturnsCorrectID()
        {
            Fika fika = new Fika();
            fika.Id = 8888;
            _fikaMock.Setup(fm => fm.GetFika(8888)).Returns(fika);
            
            Fika result = _fikaService.DeleteFika(fika.Id);

            _fikaMock.Verify(fm => fm.DeleteFika(result), Times.Once);
            Assert.AreEqual(8888, result.Id);
        }

        [TestMethod]
        public void ServicePutFikaShouldInvoteFikaRepositoryGetFikaOnce()
        {
            Fika fika = new Fika {Id = 5};
            _fikaService.PutFika(fika);

            _fikaMock.Verify(fm => fm.GetFika(5), Times.Once);
        }

    }
}
