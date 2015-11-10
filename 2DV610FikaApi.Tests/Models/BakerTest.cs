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
            string name = null;
            Baker baker = new Baker(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBakerNameIsEmty()
        {
            string name = "";
            Baker baker = new Baker(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenBakerEmailIsLessThanFourChars()
        {
            string name = "Olle";
            string email = "a@s";
            new Baker(name, email);
        }

    }
}
