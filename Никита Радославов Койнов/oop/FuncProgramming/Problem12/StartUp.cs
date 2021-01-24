using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem12
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Func<int[], int, int> leftFilter = (numbers, index) =>
            {
                int sum = numbers[index];
                try
                {
                    int leftNum = numbers[index - 1];
                    sum += leftNum;
                }
                catch (Exception)
                {
                    sum += 0;
                }

                return sum;
            };

            Func<int[], int, int> rightFilter = (numbers, index) =>
            {
                int sum = numbers[index];
                try
                {
                    int rightNum = numbers[index + 1];
                    sum += rightNum;
                }
                catch (Exception)
                {
                    sum += 0;
                }

                return sum;
            };

            Func<int[], int, int> leftRightFilter = (numbers, index) =>
            {
                int sum = numbers[index];

                try
                {
                    int leftNum = numbers[index - 1];
                    sum += leftNum;
                }
                catch (Exception)
                {
                    // sum += 0;
                }

                try
                {
                    int rightNum = numbers[index + 1];
                    sum += rightNum;
                }
                catch (Exception)
                {
                    // sum += 0;
                }

                return sum;
            };

            Stack<int[]> indexesToExclude = new Stack<int[]>();

            var gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(';');
                string command = commands[0]; // Exclude, Reverse, Forge

                if (command.Equals("Forge"))
                {
                    break;
                }

                string filter = commands[1]; // Sum Left, Sum Right, Sum Left Right
                int expecedSum = int.Parse(commands[2]);

                if (command.Equals("Exclude"))
                {
                    Func<int[], int, int> filterFunc = null;
                    switch (filter)
                    {
                        case "Sum Left":
                            filterFunc = leftFilter;
                            break;
                        case "Sum Right":
                            filterFunc = rightFilter;
                            break;
                        case "Sum Left Right":
                            filterFunc = leftRightFilter;
                            break;
                    }

                    var gemIndexesToExclude = gems
                        .Select((g, i) => new { value = g, index = i })
                        .Where(x => filterFunc(gems, x.index) == expecedSum)
                        .Select(x => x.index)
                        .ToArray();

                    indexesToExclude.Push(gemIndexesToExclude);
                }
                else if (command.Equals("Reverse"))
                {
                    indexesToExclude.TryPop(out int[] lastOperation);
                }
            }

            var indexesToRemove = indexesToExclude.SelectMany(x => x).Distinct();
            var result = gems.Where((g, i) => !indexesToRemove.Contains(i));

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
