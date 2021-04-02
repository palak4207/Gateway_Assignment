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
            // Arrange
            var input = "PALAK";
            var expectedValue = "palak";
            // Act
            var result = input.AddLowerCase();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddUpperCase()
        {
            // Arrange
            var input = "palak";
            var expectedValue = "PALAK";
            // Act
            var result = input.AddUpperCase();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void TitleCase()
        {
            // Arrange
           var input = "palak agrawal";
           var expectedValue = "Palak Agrawal";
            // Act
           var result = input.TitleCase();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckLowerCase()
        {
            // Arrange
            var input = "palak agrawal";
            var expectedValue = true;
            // Act
            var result = input.CheckLowerCase();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_FirstUpperLetter()
        {
            // Arrange
            var input = "palak";
            var expectedValue = "Palak";
            // Act
            var result = input.FirstUpperLetter();
            // Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_CheckUpperCase()
        {
            // Arrange
            var input = "PALAK";
            var expectedValue = true;
            // Act
            var result = input.CheckUpperCase();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_NumberValidation()
        {
            // Arrange
            var input = "4207";
            var expectedValue = true;
            // Act
            var result = input.NumberValidation();
            // Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_LastCharacterRemove()
        {
            // Arrange
            var input = "palak";
            var expectedValue = "pala";
            // Act
            var result = input.LastCharacterRemove();
            // Assert
            Assert.Equal(expectedValue, result);
        }


        [Fact]
        public void Test_WordCount()
        {
            // Arrange
            var input = "palak Agrawal";
            var expectedValue = 2;
            // Act
            var result = input.WordCount();
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_StringToInt()
        {
            // Arrange
            var input = "4207";
            var expectedValue = 4207;
            // Act
            var result = input.StringToInt();
            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
