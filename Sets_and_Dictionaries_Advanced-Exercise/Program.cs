using System;
using System.Collections.Generic;

namespace _01_Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var userNames = new HashSet<string>();
            var userNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < userNum; i++)
            {
                var newUser = Console.ReadLine();
                userNames.Add(newUser);
            }
            foreach (var user in userNames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
