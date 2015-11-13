using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;

namespace _2DV610FikaApi.Tests.Models
{
    [TestClass]
    public class FikaTest
    {
        [TestMethod]
        public void FikaDatePropertyShouldExist()
        {
            DateTime date = new DateTime();
            Fika fika = new Fika(date);

            Assert.AreEqual(date, fika.Date);
        }

        [TestMethod]
        public void FikaNamePropertyShouldExist()
        {
            string pastryName = "Dröm kakor";
            Mock<Fika> fika = new Mock<Fika>(pastryName);

            Assert.AreEqual(pastryName, fika.Name);
        }
    }
}
