using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var parkedCars = new HashSet<string>();

            while (command[0] != "END")
            {
                var direction = command[0].ToLower();
                var carNumber = command[1];

                if (direction == "out")
                {
                    parkedCars.Remove(carNumber);
                }
                else if (direction == "in")
                {
                    parkedCars.Add(carNumber);
                }

                command = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (parkedCars.Any())
            {
                foreach (var car in parkedCars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
