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
        /// Name of token to show. Don´t like Fizz?, Don´t like Fizz Buzz?
        /// set your own token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Number to search Multiples Of
        /// </summary>
        public int MultiplesOf { get; set; }


        /// <summary>
        /// We make shure to avoid repited numbers or tokens, in order to make sense
        /// </summary>
        /// <param name="other">FizzBuzz to compare with</param>
        /// <returns></returns>
        public bool Equals(FizzBuzz other)
        {
            return MultiplesOf == other.MultiplesOf || Token.Trim().ToLower() == other.Token.Trim().ToLower();
        }       
    }
}
