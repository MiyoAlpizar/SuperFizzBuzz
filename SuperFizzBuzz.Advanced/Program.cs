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

            //Lista of FizzBuzzes To Search for
            List<FizzBuzz> fizzBuzzes = new()
            {
                new FizzBuzz { MultiplesOf = 3, Token = "Fizz" },
                new FizzBuzz { MultiplesOf = 7, Token = "Buzz" },
                new FizzBuzz { MultiplesOf = 38, Token = "Bazz" }
            };

            //Init new instance with List of FizzBuzzess
            SuperFizzBuzz superFizzBuzz = new(fizzBuzzes);

            //Get Dictionary of FizzBuzzesOutputs
            var outputs = superFizzBuzz.FizzBuzz(startRange, endRange);
            
            
            Console.WriteLine($"--- Numbers to {startRange} to {endRange} ---");
            foreach (var item in outputs)
            {
                Console.WriteLine(item.Output);
            }
            Console.WriteLine($"--- Numbers to {startRange} to {endRange} ---\n");


            var moreThanOnce = outputs.Where(x => x.Coincidences > 1);
            Console.WriteLine("--- Combination of Tokens that matches more than once ---");
            foreach (var item in moreThanOnce)
            {
                Console.WriteLine($"{item.Number} {item.Output}");
            }
            Console.WriteLine("--- Combination of Tokens that matches more than once ---");

        }
    }
}
