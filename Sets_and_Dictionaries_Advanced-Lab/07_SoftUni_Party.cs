using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipGuest = new HashSet<string>();
            var regularGuest = new HashSet<string>();

            var newGuest = Console.ReadLine();
            while (newGuest != "PARTY")
            {
                if (newGuest.Length == 8)
                {
                    var newGuestArray = newGuest.ToCharArray();
                    if (char.IsDigit(newGuestArray[0]))
                    {
                        vipGuest.Add(newGuest);
                    }
                    else
                    {
                        regularGuest.Add(newGuest);
                    }
                }
                newGuest = Console.ReadLine();
            }
            var leavingGuest = Console.ReadLine();
            while (leavingGuest != "END")
            {
                if (leavingGuest.Length == 8)
                {
                    var newGuestArray = leavingGuest.ToCharArray();
                    if (char.IsDigit(newGuestArray[0]))
                    {
                        vipGuest.Remove(leavingGuest);
                    }
                    else
                    {
                        regularGuest.Remove(leavingGuest);
                    }
                }
                leavingGuest = Console.ReadLine();
            }
            Console.WriteLine(vipGuest.Count + regularGuest.Count);
            if (vipGuest.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuest));
            }
            if (regularGuest.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularGuest));
            }
        }
    }
}
