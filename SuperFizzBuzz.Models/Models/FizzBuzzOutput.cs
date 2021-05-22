using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFizzBuzz.Models.Models
{
    /// <summary>
    /// Class where we are goin to store the information about the FezzBuzz Outputs
    /// </summary>
    public class FizzBuzzOutput
    {
        /// <summary>
        /// Original Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Original Number Or FezzBuzz Token
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// How many times it coincides with the list of  MultipleOf FizzBuzz Property
        /// </summary>
        public int Coincidences { get; set; }
        
    }
}
