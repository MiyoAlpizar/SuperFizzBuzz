using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFizzBuzz.Models.Models
{
    /// <summary>
    /// Class To FizzBuzz Any Number
    /// </summary>
    public class FizzBuzz : IEquatable<FizzBuzz>
    {
        /// <summary>
        /// Initializes a new class of FizzBuzz
        /// </summary>
        public FizzBuzz()
        {

        }

        /// <summary>
        /// Name of token to show. Don´t like Fizz?, Don´t like Buzz?
        /// set your own token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Number to search Multiples Of
        /// </summary>
        public int Divisor { get; set; }

        /// <summary>
        /// We make shure to avoid repited divisors, in order to make sense
        /// </summary>
        /// <param name="other">FizzBuzz to compare with</param>
        /// <returns>bool</returns>
        public bool Equals(FizzBuzz other)
        {
            return Divisor == other.Divisor;
        }       
    }
}
