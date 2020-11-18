using System;

using AnimalKingdom.Models.Contracts;

namespace AnimalKingdom.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public int Age { get; private set; }

        public Animal(int age)
        {
            this.Age = age;
        }

        public abstract string MakeNoise();

        public abstract string MakeTrick();

        public virtual void Perform()
        {
            Console.WriteLine(this.MakeNoise());
            Console.WriteLine(this.MakeTrick());
        }

        public int CompareTo(IAnimal other)
        {
            if (other is null)
            {
                return -1;
            }

            if (this.GetType().Equals(other.GetType()))
            {
                return this.Age - other.Age;
            }

            return this.GetType().Name == typeof(Dog).Name ? 1 : -1;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Age}";
        }
    }
}
