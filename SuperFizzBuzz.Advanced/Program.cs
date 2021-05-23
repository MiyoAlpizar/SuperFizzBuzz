using SuperFizzBuzz.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperFizzBuzz.Advanced
{
    class Program
    {
        static void Main(string[] _)
        {
            MakeFizzBuzz();
        }
        static void MakeFizzBuzz()
        {
            var startRange = -12;
            var endRange = 145;
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { Divisor = 3, Token = "Fizz" },
                new FizzBuzz { Divisor = 7, Token = "Buzz" },
                new FizzBuzz { Divisor = 38, Token = "Bazz" }
            };
            SuperFizzBuzz superFizzBuzz = new(fizzBuzzes);
            var outputs = superFizzBuzz.FizzBuzz(startRange, endRange);
            foreach (var item in outputs)
            {
                Console.WriteLine(item);
            }
         
        }
    }
}
