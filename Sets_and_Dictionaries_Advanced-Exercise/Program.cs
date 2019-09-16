using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07_The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggFollowers = new Dictionary<string, List<string>>();
            var vloggFollowing = new Dictionary<string, List<string>>();

            var command = Console.ReadLine();
            while (command != "Statistics")
            {
                var joinedPattern = @"^(?<followerFirst>[\S]+)[\s]joined The V-Logger$";
                var followedPattern = @"^(?<followerFirst>[\S]+)[\s]followed[\s](?<followerSecond>[\S]+)$";
                var joinedMatch = Regex.Match(command, joinedPattern);
                var followedMatch = Regex.Match(command, followedPattern);
                if (joinedMatch.Success)
                {
                    var follower = joinedMatch.Groups["followerFirst"].Value;
                    if (!vloggFollowers.ContainsKey(follower))
                    {
                        vloggFollowers.Add(follower, new List<string>());
                        vloggFollowing.Add(follower, new List<string>());
                    }
                }
                else if (followedMatch.Success)
                {
                    var followed = followedMatch.Groups["followerSecond"].Value;
                    var following = followedMatch.Groups["followerFirst"].Value;

                    if (vloggFollowers.ContainsKey(followed) &&
                        vloggFollowers.ContainsKey(following) &&
                        followed != following &&
                        (!vloggFollowers[followed].Contains(following)) &&
                        (!vloggFollowing[following].Contains(followed)))
                    {
                        vloggFollowers[followed].Add(following);
                        vloggFollowing[following].Add(followed);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggFollowers.Count()} vloggers in its logs.");
            var orderdDictionary = vloggFollowers.OrderByDescending(x => x.Value.Count())
                .ThenBy(x => vloggFollowing[x.Key].Count());

            var counter = 1;

            foreach (var vlogger in orderdDictionary)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count()} followers, " +
                        $"{vloggFollowing[vlogger.Key].Count()} following");

                if (orderdDictionary.First().Key == vlogger.Key && vlogger.Value.Any())
                {
                    foreach (var follower in vlogger.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
