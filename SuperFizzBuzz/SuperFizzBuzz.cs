using System;
using System.Collections.Generic;
using System.Linq;
using SuperFizzBuzz.Models.Models;

namespace SuperFizzBuzz
{
    public class SuperFizzBuzz
    {
        #region
        /// <summary>
        /// Initializes a new instance of SuperFizzBuzz
        /// </summary>
        public SuperFizzBuzz()
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// FizzBuzzes the default array numbers from 1 to 100
        /// </summary>
        public void FizzBuzz(List<FizzBuzz> fizzBuzzes = null)
        {
            var numbersToFizzBuzz = CreateNumberArray(1, 100);
            FizzBuzzArray(numbersToFizzBuzz, fizzBuzzes);
        }

        /// <summary>
        /// FizzBuzzes any range of numbers 
        /// </summary>
        /// <param name="from">Number range to start</param>
        /// <param name="to">Number range to end</param>
        /// <param name="fizzBuzzes">List of FizzBuzz to search for, if null default values are  Fizz = 3 And Buzz = 5</param>
        public void FizzBuzz(int from, int to, List<FizzBuzz> fizzBuzzes = null)
        {
            var numberToFizzBuzz = CreateNumberArray(from, to);
            FizzBuzzArray(numberToFizzBuzz, fizzBuzzes);
        }

        /// <summary>
        /// FizzBuzzes any integer array
        /// </summary>
        /// <param name="numbers">Integer array to FizzBuzz</param>
        /// <param name="fizzBuzzes">List of FizzBuzz to search for, if null default values are  Fizz = 3 And Buzz = 5</param> 
        public void FizzBuzz(int[] numbers, List<FizzBuzz> fizzBuzzes = null)
        {
            FizzBuzzArray(numbers, fizzBuzzes);
        }
        #endregion


        #region Private Methdos
        /// <summary>
        /// FizzBuzzes any integer array
        /// </summary>
        /// <param name="arrayNumbers">Integer Array to FizzBuzz</param>
        /// <param name="fizzBuzzes">List of FizzBuzz Tokens to Evaluate</param>
        private void FizzBuzzArray(int[] numbers, List<FizzBuzz> fizzBuzzes = null)
        {
            //If FizzBuzzes to search for is null, we asign the default values
            if (fizzBuzzes == null)
            {
                fizzBuzzes = FizzBuzzTokens.FizzBuzzes;
            }

            //Orders the array number in order to optimize the search loop
            //List<int> numbers = arrayNumbers.OrderBy(x => x).ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                var FizzBuzz = "";

                foreach (var item in fizzBuzzes)
                {
                    if (number == 0) break;
                    if (number % item.MultiplesOf == 0)
                    {
                        FizzBuzz += item.Token;
                    }
                }

                if (string.IsNullOrWhiteSpace(FizzBuzz))
                {
                    Console.WriteLine(number.ToString());
                }
                else
                {
                    Console.WriteLine(FizzBuzz);
                }

            }
        }

        /// <summary>
        /// Creates an integer array
        /// </summary>
        /// <param name="from">Value to start</param>
        /// <param name="to">Value to end</param>
        /// <returns>int[]</returns>
        private int[] CreateNumberArray(int from, int to)
        {
            //Gets the maximum number
            var max = Math.Max(from, to);

            //Gets the minimun number
            var min = Math.Min(from, to);

            //Sets the lenght of the array
            int[] numbers = new int[max - min + 1];

            var j = 0;
            for (int i = min; i <= max; i++)
            {
                numbers[j] = min + j;
                j++;
            }

            return numbers;
        }
        #endregion
    }
}
