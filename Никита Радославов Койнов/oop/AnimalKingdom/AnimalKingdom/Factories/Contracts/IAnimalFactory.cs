using AnimalKingdom.Models.Contracts;

namespace AnimalKingdom.Factories.Contracts
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string animalType, int age);
    }
}
