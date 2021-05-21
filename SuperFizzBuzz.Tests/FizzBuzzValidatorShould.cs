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
        public void ReturnOneOutputWithFizzWhen3()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            int valueToLook = 3;
            int rangeStart = 1;
            int rangeEnd = valueToLook + 1;
            int indexToLook = valueToLook - 1;
            int countExpcted = 1;
            string outputExpected = "Fizz";
            
            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var values = outputs.Where(x => x.Value.Number == valueToLook).ToList();
            var value = values.FirstOrDefault().Value.Output;
            
            
            //Assert
            Assert.Equal(countExpcted, values.Count);
            Assert.Equal(outputExpected, value);

        }

        [Fact]
        public void ReturnOneOutputWithBuzzWhen5()
        {
            //Arrange
            SuperFizzBuzz superFizzBuzz = new();
            int valueToLook = 5;
            int rangeStart = 1;
            int rangeEnd = valueToLook + 1;
            int indexToLook = valueToLook - 1;
            int countExpcted = 1;
            string outputExpected = "Buzz";

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var values = outputs.Where(x => x.Value.Number == valueToLook).ToList();
            var value = values.FirstOrDefault().Value.Output;


            //Assert
            Assert.Equal(countExpcted, values.Count);
            Assert.Equal(outputExpected, value);

        }

        [Theory]
        [InlineData(7,"Fuzz")]
        [InlineData(2,"Wazz")]
        [InlineData(154, "Zass")]
        [InlineData(-15, "Wozz")]
        [InlineData(0, "Jazz")]
        [InlineData(-1, "")]
        [InlineData(1000, "Doug")]
        public void ReturnCustomTokenWithCustomMultipleOf(int multipleOf, string token)
        {
            //Arrange
            var listFizzBuzzes = new List<FizzBuzz>() {
                new FizzBuzz { MultiplesOf = multipleOf, Token = token}
            };

            SuperFizzBuzz superFizzBuzz = new(listFizzBuzzes);

            int valueToLook = multipleOf;
            //We make sure the start range is smaller than multipleOf 
            int rangeStart = Math.Min(0, multipleOf);

            //We make sure the end range is greater than multipleOf 
            int rangeEnd = multipleOf + 1;
            
            int countExpcted = 1;
            string outputExpected = token;

            //Act
            var outputs = superFizzBuzz.FizzBuzz(rangeStart, rangeEnd);
            var values = outputs.Where(x => x.Value.Number == valueToLook).ToList();
            var value = values.FirstOrDefault().Value.Output;


            //Assert
            Assert.Equal(countExpcted, values.Count);
            Assert.Equal(outputExpected, value);

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
