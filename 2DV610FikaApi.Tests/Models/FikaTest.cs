using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;

namespace _2DV610FikaApi.Tests.Models
{
    [TestClass]
    public class FikaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime date = new DateTime()
            Fika fika = new Fika(date);

            Assert.AreEqual(date, fika.Date);
        }
    }
}
