using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using _2DV610FikaApi.Models;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace _2DV610FikaApi.Tests.Controllers
{
    [TestClass]
    public class BakerControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new BakerController();
            var allBakers = controller.Get() as OkNegotiatedContentResult<List<Baker>>;

            Assert.AreEqual(0, allBakers.Content.Count);
            // Expect empty list if no bakers in the system.
        }
    }
}
