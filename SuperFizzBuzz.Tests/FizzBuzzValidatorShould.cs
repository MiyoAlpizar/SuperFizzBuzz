using SuperFizzBuzz.Models.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SuperFizzBuzz.Tests
{
    public class FizzBuzzValidatorShould
    {
        [Fact]
        public void ReturnFizzWhen3()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            int valueToLook = 3;
            int rangeStart = 1;
            int rangeEnd = valueToLook + 1;
            int indexToLook = valueToLook - 1;
            string expected = "Fizz";
            
            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];
            
            //Assert
            Assert.Equal(expected, value);

        }

        [Fact]
        public void ReturnBuzzWhen5()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            int valueToLook = 5;
            int rangeStart = 1;
            int rangeEnd = valueToLook + 1;
            int indexToLook = valueToLook - 1;
            string expected = "Buzz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];

            //Assert
            Assert.Equal(expected, value);

        }

        [Theory]
        [InlineData(7,"Fuzz")]
        [InlineData(2,"Wazz")]
        [InlineData(154, "Zass")]
        [InlineData(-15, "Wozz")]
        [InlineData(0, "Jazz")]
        [InlineData(-1, "")]
        public void ReturnCustomTokenWithCustomMultipleOf(int multipleOf, string token)
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();

            superFizzBuzz.SetFizzBuzzes(new List<FizzBuzz>() { 
                new FizzBuzz { MultiplesOf = multipleOf, Token = token}
            });
            
            
            int valueToLook = multipleOf;
            int rangeStart = Math.Min(0, multipleOf);
            int rangeEnd = Math.Max(10, multipleOf + 1);
            int indexToLook = Math.Abs(valueToLook) + rangeStart;
            string expected = token;

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];

            //Assert
            Assert.Equal(expected, value);

        }

        [Fact]
        public void RaiseErrorWhenMultiplesOfRepites()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 14, Token = "Duck" },
                new FizzBuzz { MultiplesOf = 14, Token = "Cat" }
            };
            //Act

            //Assert
            Assert.Throws<Exception>(() => superFizzBuzz.SetFizzBuzzes(fizzBuzzes));
        }

        [Fact]
        public void RaiseErrorWhenTokenRepites()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 84, Token = "Dog" },
                new FizzBuzz { MultiplesOf = 12, Token = "Dog" }
            };
            //Act

            //Assert
            Assert.Throws<Exception>(() => superFizzBuzz.SetFizzBuzzes(fizzBuzzes));
        }
    }
}
