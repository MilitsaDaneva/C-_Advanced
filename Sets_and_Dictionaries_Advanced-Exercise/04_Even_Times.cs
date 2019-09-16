using System;
using System.Collections.Generic;

namespace _04_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersAppearance = new Dictionary<int, int>();
            var numberInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInputs; i++)
            {
                var currentNum = int.Parse(Console.ReadLine());
                if (!numbersAppearance.ContainsKey(currentNum))
                {
                    numbersAppearance.Add(currentNum, 0);
                }
                numbersAppearance[currentNum]++;
            }
            foreach (var kvp in numbersAppearance)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    break;
                }
            }
        }
    }
}
