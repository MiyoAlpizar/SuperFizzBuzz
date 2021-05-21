using System;
using System.Collections.Generic;
using System.Linq;
using SuperFizzBuzz.Models.Models;

namespace SuperFizzBuzz
{
    /// <summary>
    /// Main class to FizzBuzz any integer array
    /// </summary>
    public class SuperFizzBuzz
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of SuperFizzBuzz
        /// <param name="fizzBuzzes">List of FizzBuzzes to search for</param> 
        /// If null or empty, will take the default values. Fizz = 3 And Buzz = 5
        /// </summary>
        public SuperFizzBuzz(List<FizzBuzz> fizzBuzzes = null)
        {
            if (FizzBuzzes != null)
            {
                FizzBuzzes = fizzBuzzes;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current List of FizzBuzzes that is used to search for
        /// </summary>
        public List<FizzBuzz> FizzBuzzes { get; private set; } = FizzBuzzTokens.DefaultFizzBuzzes;
        #endregion

        #region FizzBuzz Public Methods

        /// <summary>
        /// FizzBuzzes the default array numbers from 1 to 100
        /// </summary>
        public void FizzBuzz()
        {
            var numbersToFizzBuzz = CreateNumberArray(1, 100);
            FizzBuzzArray(numbersToFizzBuzz);
        }

        /// <summary>
        /// FizzBuzzes any range of numbers 
        /// </summary>
        /// <param name="from">Number range to start</param>
        /// <param name="to">Number range to end</param>
        public void FizzBuzz(int from, int to)
        {
            var numberToFizzBuzz = CreateNumberArray(from, to);
            FizzBuzzArray(numberToFizzBuzz);
        }

        /// <summary>
        /// FizzBuzzes any integer array
        /// </summary>
        /// <param name="numbers">Integer array to FizzBuzz</param>
        /// <param name="fizzBuzzes">List of FizzBuzz to search for, if null default values are  Fizz = 3 And Buzz = 5</param> 
        public void FizzBuzz(int[] numbers)
        {
            FizzBuzzArray(numbers);
        }
        #endregion

        #region Set FizzBuzz Methods
        /// <summary>
        /// Adds new FizzBuzz to the current list
        /// </summary>
        /// <param name="fizzBuzz">FizzBuzz to add to the list, if any of the MultiplesOf value or the Token repeats, 
        /// it will throw an exception</param>
        public void AddFizzBuzz(FizzBuzz fizzBuzz)
        {
            //We check if FizzBuzz is unique
            var exists = FizzBuzzes.Find(x => x.Equals(fizzBuzz)) != null;

            //If is unique
            if (!exists)
            {
                FizzBuzzes.Add(fizzBuzz);
            }
            else
            {
                throw new Exception("Division number and Token must be uniques");
            }
        }

        /// <summary>
        ///  Sets new list with custom FizzBuzzes to search for
        /// </summary>
        /// <param name="fizzBuzzes">List<FizzBuzz> to set, if any of the MultiplesOf value or the Token repeats, 
        /// it will throw an exception</param>
        public void SetFizzBuzzes(List<FizzBuzz> fizzBuzzes)
        {
            //Clears the current list
            if (fizzBuzzes?.Any() != true)
            {
                return;
            }
            FizzBuzzes.Clear();
            foreach (var fizzBuzz in fizzBuzzes)
            {
                AddFizzBuzz(fizzBuzz);
            }
        }

        /// <summary>
        /// Sets the default FizzBuzzes List - Fizz = 3, Buzz = 5
        /// </summary>
        public void SetDefaultFizzBuzz()
        {
            FizzBuzzes = FizzBuzzTokens.DefaultFizzBuzzes;
        }
        #endregion

        #region Private Methdos
        /// <summary>
        /// FizzBuzzes any integer array
        /// </summary>
        /// <param name="arrayNumbers">Integer Array to FizzBuzz</param>
        /// <param name="fizzBuzzes">List of FizzBuzz Tokens to Evaluate</param>
        private void FizzBuzzArray(int[] numbers)
        {
            //If FizzBuzzes to search for is null or empty, we asign the default values
            if (FizzBuzzes?.Any() != true)
            {
                FizzBuzzes = FizzBuzzTokens.DefaultFizzBuzzes;
            }
           
            for (int i = 0; i < numbers.Length; i++)
            {
                //Number in array to evaluate
                var number = numbers[i];

                //String to storage and accumulate the tokens found in the modules of multiplesOf
                var FizzBuzz = "";
                
                //We loop for the list of FizzBuzz to find matches
                foreach (var item in FizzBuzzes)
                {
                    //We can´t divide by 0, so in case of 0, we break
                    if (number == 0) break;
                    
                    //If module is 0, we just found a token to show instade of the number
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
