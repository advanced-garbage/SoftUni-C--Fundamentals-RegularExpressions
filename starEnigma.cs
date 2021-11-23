using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace starEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedPlanets = new List<string>();
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();
            var pattern
                = @"@(?<planet>[A-Za-z]+)[^@\-!,:>]*:(?<population>\d+)[^@\-!,:>]*!(?<AoD>[A]|[D])![^@\-!,:>]*->(?<soldierCount>\d+)";
            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                var toDecrypt = Console.ReadLine();
                int starCount = 0;
                for (int i = 0; i < toDecrypt.Length; i++)
                {
                    switch (toDecrypt[i])
                    {
                        case 'S':
                        case 'T':
                        case 'A':
                        case 'R':
                        case 's':
                        case 't':
                        case 'a':
                        case 'r':
                            starCount++;
                            break;
                    }
                }
                var encryptedWord = new StringBuilder();
                for (int i = 0; i < toDecrypt.Length; i++)
                {
                    encryptedWord.Append(Convert.ToChar(toDecrypt[i] - starCount));
                }
                Match match = Regex.Match(encryptedWord.ToString(), pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    var planet = match.Groups["planet"].Value;
                    var AoD = match.Groups["AoD"].Value;

                    if (AoD == "A")
                        attackedPlanets.Add(planet);
                    else
                        destroyedPlanets.Add(planet);
                }
            }

            attackedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var attackedPlanet in attackedPlanets)
            {
                Console.WriteLine("-> " + attackedPlanet);
            }
            destroyedPlanets.Sort();
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var destroyedPlanet in destroyedPlanets)
            {
                Console.WriteLine("-> " + destroyedPlanet);
            }

        }
    }
}
