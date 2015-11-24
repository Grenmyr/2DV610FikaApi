using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
            Fika fika = new Fika();
            fika.Pastry = _validPastry;
            fika.Date = _validDateTime;

            Assert.AreEqual(_validDateTime, fika.Date);
        }

        [TestMethod]
        public void FikaPastryPropertyShouldExist()
        {
            Fika fika = new Fika();
            fika.Date = _validDateTime;
            fika.Pastry = _validPastry;

            Assert.AreEqual(_validPastry, fika.Pastry);
        }

        [TestMethod]
        public void FikaPastryPropertyDoesNotAllowNullValues()
        {
            Fika fika = new Fika();

            fika.Pastry = null;

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(fika, new ValidationContext(fika), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void FikaPastryPropertyDoesNotAllowEmtryStringValues()
        {
            Fika fika = new Fika();
            
            fika.Pastry = String.Empty;

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(fika, new ValidationContext(fika), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void FikaPastryPropertyDoesNotAllowStringsLongerThen30CharactersLength()
        {
            Fika fika = new Fika();

            fika.Pastry = "ThisisExactlythritytwocharacters";

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(fika, new ValidationContext(fika), validationResults, true);
 
            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }
    }
}
