using SuperFizzBuzz.Models.Models;
using System;
using System.Collections.Generic;

namespace SuperFizzBuzz.Advanced
{
    class Program
    {
        static readonly SuperFizzBuzz superFizzBuzz = new();
        static void Main(string[] _)
        {
            ExampleA();
            ExampleB();
        }

        static void ExampleA()
        {
            superFizzBuzz.SetDefaultFizzBuzz();
            Console.WriteLine("--- Example -12 to 145 ---");
            superFizzBuzz.FizzBuzz(-12, 145);
            Console.WriteLine("--- Example -12 to 145 ---\n");
        }

        static void ExampleB()
        {
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 3, Token = "Fizz" },
                new FizzBuzz { MultiplesOf = 7, Token = "Buzz" },
                new FizzBuzz { MultiplesOf = 38, Token = "Bazz" }
            };

            superFizzBuzz.SetFizzBuzzes(fizzBuzzes);
            superFizzBuzz.FizzBuzz(-3, 1000);
        }
    }
}
