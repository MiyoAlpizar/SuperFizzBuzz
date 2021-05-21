using System;

namespace SuperFizzBuzz.Clasic
{
    class Program
    {
        static void Main(string[] _)
        {
            SuperFizzBuzz superFizzBuzz = new();
            var outputs = superFizzBuzz.FizzBuzz();
            foreach (var item in outputs)
            {
                Console.WriteLine(item.Value.Output);
            }
        }
    }
}
