using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace Testing_test
{
    [TestClass]
    public class UnitTest1
    {

        [Fact]
        public void Test_AddLowerCase()
        {
            //Arrange
            var input = "PALAK";
            var expectedValue = "palak";
            // Act
            var result = ExtensionMethod.AddLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddUpperCase()
        {
            //Arrange
            var input = "palak";
            var expectedValue = "PALAK";
            // Act
            var result = ExtensionMethod.AddUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void TitleCase()
        {
            //Arrange
           var input = "palak agrawal";
           var expectedValue = "Palak Agrawal";
            //Act
           var result = ExtensionMethod.TitleCase(input);

            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckLowerCase()
        {
            //Arrange
            var input = "palak agrawal";
            var expectedValue = true;
            // Act
            var result = ExtensionMethod.CheckLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_FirstUpperLetter()
        {
            //Arrange
            var input = "palak";
            var expectedValue = "Palak";
            // Act
            var result = ExtensionMethod.FirstUpperLetter(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_CheckUpperCase()
        {
            //Arrange
            var input = "PALAK";
            var expectedValue = true;
            // Act
            var result = ExtensionMethod.CheckUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_NumberValidation()
        {
            //Arrange
            var input = "4207";
            var expectedValue = true;
            // Act
            var result = ExtensionMethod.NumberValidation(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_LastCharacterRemove()
        {
            //Arrange
            var input = "palak";
            var expectedValue = "pala";
            // Act
            var result = ExtensionMethod.LastCharacterRemove(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_WordCount()
        {
            //Arrange
            var input = "palak Agrawal";
            var expectedValue = 2;
            // Act
            var result = ExtensionMethod.WordCount(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_StringToInt()
        {
            //Arrange
            var input = "4207";
            var expectedValue = 4207;
            // Act
            var result = ExtensionMethod.StringToInt(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
