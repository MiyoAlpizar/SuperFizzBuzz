using SuperFizzBuzz.Models.Models;
using System;
using System.Collections.Generic;

namespace SuperFizzBuzz.Advanced
{
    class Program
    {
        static void Main(string[] _)
        {
            SuperFizzBuzz superFizzBuzz = new();
            Console.WriteLine("--- Example -12 to 145 ---");
            superFizzBuzz.FizzBuzz(-12, 145);
            Console.WriteLine("--- Example -12 to 145 ---\n");

            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 3, Token = "Fizz" },
                new FizzBuzz { MultiplesOf = 7, Token = "Buzz" },
                new FizzBuzz { MultiplesOf = 38, Token = "Bazz" }
            };

            superFizzBuzz.FizzBuzzes = fizzBuzzes;
            superFizzBuzz.FizzBuzz(1,999);
        }
    }
}
