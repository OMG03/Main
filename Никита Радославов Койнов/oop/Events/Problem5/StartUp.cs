using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            var people = new List<Person>();

            var royalGuards = Console.ReadLine()
                .Split()
                .Select(x => new RoyalGuard(x));
            people.AddRange(royalGuards);

            var footmen = Console.ReadLine()
                .Split()
                .Select(x => new Footman(x));
            people.AddRange(footmen);

            people.ForEach(x => king.Attacked += x.OnAttacked);
            people.ForEach(x => x.WhenKilled(() =>
            {
                king.Attacked -= x.OnAttacked;
                people.Remove(x);
            }));

            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("End"))
                {
                    break;
                }

                var splittedLine = line.Split();
                var command = splittedLine[0];
                var name = splittedLine[1];

                switch (command)
                {
                    case "Attack":
                        king.OnAttacked();
                        break;
                    case "Kill":
                        people.First(p => p.Name.Equals(name)).TryToKill();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
