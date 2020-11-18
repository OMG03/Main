using AnimalKingdom.Factories.Contracts;
using AnimalKingdom.Models.Animals;
using AnimalKingdom.Models.Contracts;

namespace AnimalKingdom.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string animalType, int age)
        {
            return animalType switch
            {
                "Dog" => new Dog(age),
                "Cat" => new Cat(age),
                _ => null
            };
        }
    }
}
