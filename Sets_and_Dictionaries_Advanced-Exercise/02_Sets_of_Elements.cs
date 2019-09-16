using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCollection = new HashSet<decimal>();
            var secondCollection = new HashSet<decimal>();

            var lengthOfCollections = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstLength = lengthOfCollections[0];
            var secondLength = lengthOfCollections[1];

            for (int i = 0; i < firstLength; i++)
            {
                var number = decimal.Parse(Console.ReadLine());
                firstCollection.Add(number);
            }
            for (int i = 0; i < secondLength; i++)
            {
                var number = decimal.Parse(Console.ReadLine());
                secondCollection.Add(number);
            }
            foreach (var number in firstCollection)
            {
                if (secondCollection.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
