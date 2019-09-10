using System;
using System.Collections.Generic;

namespace _05_Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesNum = int.Parse(Console.ReadLine());
            var namesCollection = new HashSet<string>();

            for (int i = 0; i < namesNum; i++)
            {
                var currentName = Console.ReadLine();
                namesCollection.Add(currentName);                    
            }

            foreach (var name in namesCollection)
            {
                Console.WriteLine(name);
            }
        }
    }
}
