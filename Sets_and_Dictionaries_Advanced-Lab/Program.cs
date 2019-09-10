using System;
using System.Collections.Generic;

namespace _03_Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopDict = new SortedDictionary<string, Dictionary<string, double>>();
            var shopInputInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (shopInputInfo[0] != "Revision")
            {
                var shop = shopInputInfo[0];
                var product = shopInputInfo[1];
                var price = double.Parse(shopInputInfo[2]);

                if (!shopDict.ContainsKey(shop))
                {
                    shopDict.Add(shop, new Dictionary<string, double>());
                }
                if (!shopDict[shop].ContainsKey(product))
                {
                    shopDict[shop].Add(product, 0.00);
                }
                shopDict[shop][product] = price;

                shopInputInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var shop in shopDict)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
