using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace are
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this dictionary contains the demon's(string key) name and their total health + base damage (dictionary value with two double types)
            var demonInfo = new SortedDictionary<string, Dictionary<double, double>>();

            string[] input = Console.ReadLine()
                             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => x.Trim())
                             .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                var currDemonName = input[i];
                demonInfo.Add(currDemonName, new Dictionary<double, double>());

                var totalHealth = GetDemonTotalHealth(currDemonName);
                var baseDamage = GetDemonBaseDamage(currDemonName);
                demonInfo[currDemonName].Add(totalHealth, baseDamage);
            }

            foreach (var demon in demonInfo)
            {
                Console.Write($"{demon.Key}");
                foreach (var stats in demon.Value)
                {
                    Console.Write($" - {stats.Key} health, {stats.Value:F2} damage");
                }
                Console.WriteLine();
            }
        }

        // method for calculating the demon's base damage
        static double GetDemonBaseDamage(string currDemon)
        {
            var numsInExpression = new List<double>();
            var sumPattern = @"(?<expression>[\-]?\d+[.\d+]*)";
            double damageSum = 0.0;
            MatchCollection match = Regex.Matches(currDemon, sumPattern, RegexOptions.IgnoreCase);
            foreach (var element in match)
                numsInExpression.Add(double.Parse(element.ToString()));
            damageSum = numsInExpression.Sum();

            var SumPattern2 = @"[*\/]";
            MatchCollection matches = Regex.Matches(currDemon, SumPattern2, RegexOptions.IgnoreCase);
            string stringOfOps = string.Join("", matches);
            for (int i = 0; i < stringOfOps.Length; i++)
            {
                if (stringOfOps[i] == '*')
                    damageSum *= 2;
                else if (stringOfOps[i] == '/')
                    damageSum /= 2;
            }

            return damageSum;
        }

        // simply extracting everything that isn't a number & operator and adding its ascii code sum
        static double GetDemonTotalHealth(string currDemon)
        {
            var pattern = @"[^0-9+\-*\/\.]";
            string allValidChars = string.Empty;
            MatchCollection match = Regex.Matches(currDemon, pattern);
            allValidChars = string.Join("", match);
            var totalHealth = 0;
            for (int j = 0; j < allValidChars.Length; j++)
            {
                totalHealth += (int)allValidChars[j];
            }

            return totalHealth;
        }
    }
}
