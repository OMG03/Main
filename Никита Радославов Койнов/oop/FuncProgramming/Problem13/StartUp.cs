using System;
using System.Linq;

namespace Problem13
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Func<string, int, bool> isNameBigger = (na, nu) =>
                {
                    int nameSum = 0;
                    foreach (var character in na)
                    {
                        nameSum += character;
                    }
                    return nameSum >= nu;
                };

            Func<Func<string, int, bool>, int, string[], string> getBiggestName = (f, nu, ns) =>
            {
                return ns.FirstOrDefault(x => f(x, nu));
            };

            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            string biggestName = getBiggestName(isNameBigger, number, names);
            Console.WriteLine(biggestName);
        }
    }
}
