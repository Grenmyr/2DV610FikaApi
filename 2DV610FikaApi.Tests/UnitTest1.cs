using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using _2DV610FikaApi.Models.Services;
using System.Web.Http.Results;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class FikaControllerTest
    {
        [TestMethod]
        public void ShouldReturnString()
        {
            IFikaService _service = new FikaService();
            FikaController controller = new FikaController(_service);
            IHttpActionResult actionResult = controller.Get();

            var result = actionResult as OkNegotiatedContentResult<String>;
            Assert.AreEqual("test", result.Content);
        }
    }
}
