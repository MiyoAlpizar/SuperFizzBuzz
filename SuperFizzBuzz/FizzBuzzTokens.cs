using SuperFizzBuzz.Models.Models;
using SuperFizzBuzz.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFizzBuzz
{
    /// <summary>
    /// Static class to Get And Set the FizzBuzz List to search For
    /// </summary>
    public static class FizzBuzzTokens
    {

        /// <summary>
        /// Default Values 
        /// </summary>
        private static List<FizzBuzz> _DefaultFizzBuzzes = new List<FizzBuzz>() { 
             new FizzBuzz { Token = Constants.FIZZ, MultiplesOf = 3},
             new FizzBuzz { Token = Constants.BUZZ, MultiplesOf = 5},
        };

        /// <summary>
        /// Gets the current list of FizzBuzz
        /// </summary>
        public static List<FizzBuzz> FizzBuzzes { get; private set; } = _DefaultFizzBuzzes;


        /// <summary>
        /// Ads new FizzBuzz to the List
        /// </summary>
        /// <param name="fizzBuzz">FizzBuzz to Add</param>
        public static void AddFizzBuzz(FizzBuzz fizzBuzz)
        {
            //We check if FizzBuzz is unique
            var exists = FizzBuzzes.Find(x => x.Equals(fizzBuzz)) != null;
            
            //If is unique
            if(!exists)
            {
                FizzBuzzes.Add(fizzBuzz);
            }else
            {
                throw new Exception("Division number and Token must be uniques");
            }
        }

        /// <summary>
        /// Sets new list with custom FizzBuzzes to search for
        /// </summary>
        /// <param name="fizzBuzzes">List<FizzBuzz></param>
        public static void SetFizzBuzzes(List<FizzBuzz> fizzBuzzes)
        {
            //Clears the current list
            FizzBuzzes.Clear();
            foreach (var fizzBuzz in fizzBuzzes)
            {
                AddFizzBuzz(fizzBuzz);
            }
        } 

    }
}
