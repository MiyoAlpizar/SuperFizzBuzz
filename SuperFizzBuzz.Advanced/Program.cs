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
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 3, Token = "Fizz" },
                new FizzBuzz { MultiplesOf = 7, Token = "Buzz" },
                new FizzBuzz { MultiplesOf = 38, Token = "Bazz" }
            };
            SuperFizzBuzz superFizzBuzz = new(fizzBuzzes);

            var outputs = superFizzBuzz.FizzBuzz(-12, 145);
            Console.WriteLine("--- Numbers to -12 to 145 ---");
            foreach (var item in outputs)
            {
                Console.WriteLine(item.Value.Output);
            }
            Console.WriteLine("--- Numbers to -12 to 145 ---\n");


            var moreThanOnce = outputs.Where(x => x.Value.Coincidences > 1);
            Console.WriteLine("--- Combination of Tokens that matches more than once ---");
            foreach (var item in moreThanOnce)
            {
                Console.WriteLine($"{item.Value.Number} {item.Value.Output}");
            }
            Console.WriteLine("--- Combination of Tokens that matches more than once ---");

        }
    }
}
