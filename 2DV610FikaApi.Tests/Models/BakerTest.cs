using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class BakerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBakerNameIsNull()
        {
            string nullName = null;
            string validEmail = "abc@abc.com";
            new Baker(nullName, validEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBakerNameIsEmty()
        {
            string emtyName = "";
            string validEmail = "abc@abc.com";
            new Baker(emtyName, validEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBakerEmailIsLessThanFourChars()
        {
            string validName = "Olle";
            string toShortEmail = "a@s";
            new Baker(validName, toShortEmail);
        }

    }
}
