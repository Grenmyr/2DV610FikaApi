using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace _2DV610FikaApi.Tests.Models
{
    [TestClass]
    public class FikaTest
    {
        private DateTime _validDateTime;
        private string _validPastry;

        [TestInitialize]
        public void TestInitialize()
        {
            _validDateTime = new DateTime();
            _validPastry = "Dröm kakor";
        }
        [TestMethod]
        public void FikaDatePropertyShouldExist()
        {
            Fika fika = new Fika(_validDateTime, _validPastry);

            Assert.AreEqual(_validDateTime, fika.Date);
        }

        [TestMethod]
        public void FikaPastryPropertyShouldExist()
        {
            Fika fika = new Fika(_validDateTime, _validPastry);

            Assert.AreEqual(_validPastry, fika.Pastry);
        }

        [TestMethod]
        public void FikaPastryPropertyDoesNotAllowNullValues()
        {
            Fika fika = new Fika(_validDateTime, null);

            Assert.IsNotNull(fika.Pastry);

        }

        [TestMethod]
        public void FikaPastryPropertyDoesNotAllowEmtryStringValues()
        {
            Fika fika = new Fika(_validDateTime, String.Empty);

            Assert.AreNotEqual(String.Empty, fika.Pastry);

        }
    }
}
