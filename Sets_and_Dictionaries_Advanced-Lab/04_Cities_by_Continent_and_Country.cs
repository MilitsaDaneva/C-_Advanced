using System;
using System.Collections.Generic;

namespace _04_Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var citiesNum = int.Parse(Console.ReadLine());
            var continentCountriesDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < citiesNum; i++)
            {
                var cityInputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var continent = cityInputInfo[0];
                var country = cityInputInfo[1];
                var city = cityInputInfo[2];

                if (!continentCountriesDict.ContainsKey(continent))
                {
                    continentCountriesDict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentCountriesDict[continent].ContainsKey(country))
                {
                    continentCountriesDict[continent].Add(country, new List<string>());
                }
                continentCountriesDict[continent][country].Add(city);
            }

            foreach (var continet in continentCountriesDict)
            {
                Console.WriteLine($"{continet.Key}:");
                foreach (var country in continet.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
