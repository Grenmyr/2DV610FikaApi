using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DV610FikaApi.Models;
using Moq;
using System.Collections.Generic;
using _2DV610FikaApi.Models.Repositories;

namespace _2DV610FikaApi.Tests
{
    [TestClass]
    public class BakerTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BakerShouldThrowExceptionWhenBakerNameIsNull()
        {
            string nullName = null;
            string validEmail = "abc@abc.com";
            
            new Baker(nullName, validEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BakerShouldThrowExceptionWhenBakerNameIsEmty()
        {
            string emtyName = "";
            string validEmail = "abc@abc.com";
            
            new Baker(emtyName, validEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BakerShouldThrowExceptionWhenBakerNameIsMoreThanTwentyChars()
        {
            string toLongName = "abcdefghijklmnopqrstuvxyzåäö";
            string validEmail = "abc@abc.com";
            
            new Baker(toLongName, validEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BakerShouldThrowExceptionWhenBakerEmailIsLessThanFourChars()
        {
            string validName = "Olle";
            string toShortEmail = "a@s";
            
            new Baker(validName, toShortEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BakerShouldThrowArgumentExceptionWhenBakerEmailLengthIsMoreThen254Characters()
        {
            string validName = "Olle";
            string toLongEmail = String.Format
                ("MoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoreThen254CharactersMoR");
            
            new Baker(validName, toLongEmail);
        }

        [TestMethod]
        public void BakerShouldSetValidBaker()
        {          
            string validName = "Olle";
            string validEmail = "abc@abc.com";

            new Baker(validName, validEmail);
        }     
    }
}
