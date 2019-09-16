using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorInputNum = int.Parse(Console.ReadLine());
            var wardrobeByItem = new Dictionary<string, List<string>>(); //item -> all available colors
            var wardrobeByColor = new Dictionary<string, List<string>>(); //color -> all available items
            for (int i = 0; i < colorInputNum; i++)
            {
                var colorInputArray = Console
                    .ReadLine()
                    .Split(" -> ");

                var currentColor = colorInputArray[0];

                var currentItemsArray = colorInputArray[1]               
                    .Split(',');

                if (!wardrobeByColor.ContainsKey(currentColor))
                {
                    wardrobeByColor.Add(currentColor, new List<string>());
                }
                foreach (var item in currentItemsArray)
                {
                    if (!wardrobeByItem.ContainsKey(item))
                    {
                        wardrobeByItem.Add(item, new List<string>());
                    }
                    wardrobeByItem[item].Add(currentColor);

                    if (!wardrobeByColor[currentColor].Contains(item))
                    {
                        wardrobeByColor[currentColor].Add(item);
                    }

                }
            }
            var foundItemArray = Console
                .ReadLine()
                .Split();

            var foundColor = foundItemArray[0];
            var foundItem = foundItemArray[1];

            foreach (var color in wardrobeByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    if (color.Key == foundColor && item == foundItem)
                    {
                        Console.WriteLine($"* {item} - {wardrobeByItem[item].Count(x => x == color.Key)} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {wardrobeByItem[item].Count(x => x == color.Key)}");
                    }
                }
            }
        }
    }
}
