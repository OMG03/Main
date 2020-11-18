using System;
using System.Linq;

using AnimalKingdom.Factories;
using AnimalKingdom.Factories.Contracts;

namespace AnimalKingdom
{
    public class StartUp
    {
        private static readonly IAnimalFactory animalFactory = new AnimalFactory();

        public static void Main(string[] args)
            => Console.ReadLine()
                      .Split()
                      .SelectMany(x => new object[int.Parse(x)])
                      .Select(x => Console.ReadLine().Split())
                      .Select(x => animalFactory.CreateAnimal(x[0], int.Parse(x[1])))
                      .OrderBy(x => x)
                      .ToList()
                      .ForEach(Console.WriteLine);
    }
}
