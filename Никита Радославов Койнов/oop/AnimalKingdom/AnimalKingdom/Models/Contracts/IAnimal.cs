using System;

namespace AnimalKingdom.Models.Contracts
{
    public interface IAnimal : IMakeNoise, IMakeTrick, IComparable<IAnimal>
    {
        int Age { get; }

        void Perform();
    }
}
