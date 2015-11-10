using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using _2DV610FikaApi.Controllers;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class FikaControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FikaController controller = new FikaController();
            var result = controller.Get();
            Assert.AreEqual("test", result);
        }
    }
}
