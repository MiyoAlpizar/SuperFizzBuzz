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
        private static readonly List<FizzBuzz> _DefaultFizzBuzzes = new List<FizzBuzz>() { 
             new FizzBuzz { Token = Constants.FIZZ, Divisor = 3},
             new FizzBuzz { Token = Constants.BUZZ, Divisor = 5},
        };

        /// <summary>
        /// Gets the default list of FizzBuzz
        /// </summary>
        public static List<FizzBuzz> DefaultFizzBuzzes { get; private set; } = _DefaultFizzBuzzes;
    }
}
