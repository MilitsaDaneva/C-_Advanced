using System;
using System.Collections.Generic;

namespace _05_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console
                .ReadLine()
                .ToCharArray();

            var charDictionary = new SortedDictionary<char, int>();
            foreach (var symbol in inputString)
            {
                if (!charDictionary.ContainsKey(symbol))
                {
                    charDictionary.Add(symbol, 0);
                }
                charDictionary[symbol]++;
            }
            foreach (var kvp in charDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
