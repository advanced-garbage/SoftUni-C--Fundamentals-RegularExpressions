using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace extractMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mailRegex = new Regex(@"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))");
            string input = Console.ReadLine();
            MatchCollection matches = mailRegex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
