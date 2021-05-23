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
            string expectedOutput = "Fizz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(0, 3);
            var value = outputs[3];
            
            
            //Assert
           Assert.Equal(expectedOutput, value);

        }

        [Fact]
        public void ReturnBuzzWhen5()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            string expectedOutput = "Buzz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(0, 5);
            var value = outputs[5];


            //Assert
            Assert.Equal(expectedOutput, value);

        }

        [Theory]
        [InlineData(-12, -35)]
        [InlineData(0, 15)]
        [InlineData(-5, 8)]
        [InlineData(5, -35)]
        public void ReturnInvertedOrderArrayWithInvertedInputs(int from, int to)
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

        [Fact]
        public void ReturnFrogDuckChickenInNoSequencialIntegers()
        {
            //Arrange
            List<FizzBuzz> fizzBuzzes = new ()
            {
                new FizzBuzz { Divisor = 4, Token = "Frog" },
                new FizzBuzz { Divisor = 13, Token = "Duck" },
                new FizzBuzz { Divisor = 9, Token = "Chicken" }
            };

            SuperFizzBuzz superFizzBuzz = new(fizzBuzzes);

            var expectedOutput = new string[] { "Frog", "Duck", "Chicken", "FrogDuck", "FrogChicken", "FrogDuckChicken" };
            

            //Act
            var outputs = superFizzBuzz.FizzBuzz(new int[] {4,13,9,52,36,468});
            
            //Assert
            Assert.Equal(expectedOutput, outputs);
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
