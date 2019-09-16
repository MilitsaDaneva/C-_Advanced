using System;
using System.Collections.Generic;

namespace _03_Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalEllements = new SortedSet<string>();
            var numberInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInputs; i++)
            {
                var chemEllementsArray = Console
                    .ReadLine()
                    .Split();
                for (int x = 0; x < chemEllementsArray.Length; x++)
                {
                    chemicalEllements.Add(chemEllementsArray[x]);
                }
            }
            Console.WriteLine(string.Join(" ", chemicalEllements));
        }
    }
}
