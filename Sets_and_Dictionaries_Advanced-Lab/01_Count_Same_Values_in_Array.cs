using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var numbersDict = new Dictionary<double, int>();
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!numbersDict.ContainsKey(inputArray[i]))
                {
                    numbersDict.Add(inputArray[i], 0);
                }
                numbersDict[inputArray[i]]++;
            }
            foreach (var num in numbersDict)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
