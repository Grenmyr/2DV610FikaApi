using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2DV610FikaApi.Controllers;
using System.Web.Http.Results;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class FikaControllerTest
    {
        [TestMethod]
        public void ShouldReturnString()
        {
            FikaController controller = new FikaController();
            IHttpActionResult actionResult = controller.Get();

            var result = actionResult as OkNegotiatedContentResult<String>;
            Assert.AreEqual("test", result.Content);
        }
    }
}
