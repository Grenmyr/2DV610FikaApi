using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;
using System.Collections.Generic;
using _2DV610FikaApi.Models.Repositories;
using System.ComponentModel.DataAnnotations;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class BakerTest
    {

        [TestMethod]
        public void BakerEmailPropertyDoesNotAllowNullValues()
        {
            string nullName = null;
            string validEmail = "abc@abc.com";          
            Baker baker = new Baker(nullName, validEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void BakerNamePropertyDoesNotAllowEmtyStrings()
        {
            string emtyName = "";
            string validEmail = "abc@abc.com";           
            Baker baker = new Baker(emtyName, validEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void BakerNamePropertyDoesNotAllowStringsLongerThenThanTwentyChars()
        {
            string toLongName = "abcdefghijklmnopqrstuvxyzåäö";
            string validEmail = "abc@abc.com";            
            Baker baker = new Baker(toLongName, validEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void BakerEmailPropertyDoesNotAllowStringsShorterThenFourChracters()
        {
            string validName = "Olle";
            string toShortEmail = "a@s";           
            Baker baker = new Baker(validName, toShortEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void BakerEmailPropertyDoesNotAllowMoreThen254Characters()
        {
            string validName = "Olle";
            string toLongEmail = String.Format
                ("MoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoR");         
            Baker baker = new Baker(validName, toLongEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsFalse(actual);
            Assert.AreEqual(1, validationResults.Count);
        }

        [TestMethod]
        public void BakerShouldSetValidBaker()
        {          
            string validName = "Olle";
            string validEmail = "abc@abc.com";
            Baker baker = new Baker(validName, validEmail);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool actual = Validator.TryValidateObject(baker, new ValidationContext(baker), validationResults, true);

            Assert.IsTrue(actual);
            Assert.AreEqual(0, validationResults.Count);
        }     
    }
}
