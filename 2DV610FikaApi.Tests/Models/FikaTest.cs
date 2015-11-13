using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;

namespace _2DV610FikaApi.Tests.Models
{
    [TestClass]
    public class FikaTest
    {
        private DateTime _validDateTime;
        private string _validPastry;
        private Mock<Baker> _Baker;

        [TestInitialize]
        public void TestInitialize()
        {
            _validDateTime = new DateTime();
            _validPastry = "Dröm kakor";
            _Baker = new Mock<Baker>("Olle", "myMail@coolMail.moc");
        }
        [TestMethod]
        public void FikaDatePropertyShouldExist()
        {
            Fika fika = new Fika(_validDateTime, _validPastry, _Baker.Object.Email);

            Assert.AreEqual(_validDateTime, fika.Date);
        }

        [TestMethod]
        public void FikaNamePropertyShouldExist()
        {
            Fika fika = new Fika(_validDateTime, _validPastry, _Baker.Object.Email);

            Assert.AreEqual(_validPastry, fika.Pastry);
        }

        [TestMethod]
        public void FikaEmailPropertyShouldExist()
        {
            Fika fika = new Fika(_validDateTime, _validPastry, _Baker.Object.Email);

            Assert.AreEqual(_Baker.Object.Email, fika.BakerEmail);
        }
    }
}
