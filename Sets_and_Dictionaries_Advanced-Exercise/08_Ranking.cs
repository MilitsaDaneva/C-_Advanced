using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestPass = new Dictionary<string, string>();
            var userResults = new SortedDictionary<string, List<Contest>>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end of contests")
                {
                    break;
                }
                var commandArray = command.Split(':');
                if (commandArray.Length != 2)
                {
                    break;
                }
                var contestName = commandArray[0];
                var contestPassword = commandArray[1];
                if (!contestPass.ContainsKey(contestName))
                {
                    contestPass.Add(contestName, contestPassword);
                }
            }
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end of submissions")
                {
                    break;
                }
                var commandArray = command.Split("=>");
                var contestName = commandArray[0];
                var contestPassword = commandArray[1];
                var userName = commandArray[2];
                var userPoints = int.Parse(commandArray[3]);
                if ((!contestPass.ContainsKey(contestName)) ||
                    (contestPass[contestName] != contestPassword))
                {
                    continue;
                }
                else
                {
                    if (!userResults.ContainsKey(userName))
                    {
                        userResults.Add(userName, new List<Contest>());
                    }
                    if (!userResults[userName].Any(x => x.Name == contestName))
                    {
                        userResults[userName].Add(new Contest() { Name = contestName, Points = userPoints });
                    }
                    var index = userResults[userName].FindIndex(x => x.Name == contestName);
                    userResults[userName][index].Points = Math.Max(userResults[userName][index].Points, userPoints);
                }
            }

            var orderedDictionaryByPoints = userResults.OrderByDescending(x => x.Value.Sum(y => y.Points));
            var bestCandidateName = orderedDictionaryByPoints.First().Key;
            var bestCandidatePoints = orderedDictionaryByPoints.First().Value.Sum(x => x.Points);

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in userResults)
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x => x.Points))
                {
                    Console.WriteLine($"#  {contest.Name} -> {contest.Points}");
                }
            }
        }
    }

    class Contest
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}
