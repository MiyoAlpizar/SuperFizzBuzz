using SuperFizzBuzz.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string expectedOutput = "Fizz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];
            
            
            //Assert
           Assert.Equal(expectedOutput, value);

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
            string expectedOutput = "Buzz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];


            //Assert
            Assert.Equal(expectedOutput, value);

        }

        [Theory]
        [InlineData(-12, -35)]
        [InlineData(0, 15)]
        [InlineData(-5, 8)]
        [InlineData(5, -35)]
        public void ReturnDifferentOrderWithInvertedInput(int from, int to)
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();

            int expectedFirstValueA = from;
            int expectedLastValueA = to;

            int expectedFirstValueB = to;
            int expectedLastValueB = from;

            //Act
            var outputsA = superFizzBuzz.CreateNumberArray(from, to);
            var outputsB = superFizzBuzz.CreateNumberArray(to, from);

            //Assert
            Assert.Equal(expectedFirstValueA, outputsA[0]);
            Assert.Equal(expectedLastValueA, outputsA[^1]);

            Assert.Equal(expectedFirstValueB, outputsB[0]);
            Assert.Equal(expectedLastValueB, outputsB[^1]);

        }

        [Theory]
        [InlineData(-16, "Fuzz")]
        [InlineData(25, "Wazz")]
        [InlineData(65, "Zass")]
        [InlineData(-2, "Wozz")]
        [InlineData(0, "Jazz")]
        [InlineData(-1, "")]
        [InlineData(89, "Doug")]
        public void ReturnCustomTokenWithCustomDivisor(int divisor, string token)
        {
            //Arrange
            var listFizzBuzzes = new List<FizzBuzz>() {
                new FizzBuzz { Divisor = divisor, Token = token}
            };

            SuperFizzBuzz superFizzBuzz = new(listFizzBuzzes);

            int valueToLook = divisor;

            //We make sure the start range is smaller than multipleOf 
            int rangeStart = Math.Min(0, divisor);

            //We make sure the end range is greater than multipleOf 
            int rangeEnd = divisor + 1;

            string expectedOutput = token;

            int indexToLook = divisor > 0 ? valueToLook  : 0;

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var value = outputs[indexToLook];


            //Assert
           Assert.Equal(expectedOutput, value);

        }


        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(0)]
        public void ReturnSameCountOfMatchesAsRequired(int requiredMatches)
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            int[] numbers = new int[requiredMatches];
            for (int i = 0; i < requiredMatches; i++)
            {
                numbers[i] = 3;
            }
            int expectedCount = requiredMatches;
            //Act
            var outputs = superFizzBuzz.FizzBuzz(numbers);
            //Assert
            Assert.Equal(expectedCount, outputs.Length);
        }

        [Fact]
        public void RaiseErrorWhenDivisorRepites()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { Divisor = 14, Token = "Duck" },
                new FizzBuzz { Divisor = 14, Token = "Cat" }
            };
            //Act

            //Assert
            Assert.Throws<Exception>(() => superFizzBuzz.SetFizzBuzzes(fizzBuzzes));
        }

        
    }
}
