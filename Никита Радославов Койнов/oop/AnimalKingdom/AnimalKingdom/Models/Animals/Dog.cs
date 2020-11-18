namespace AnimalKingdom.Models.Animals
{
    public class Dog : Animal
    {
        public Dog(int age) 
            : base(age)
        {
        }

        public override string MakeNoise()
        {
            return "Woof!";
        }

        public override string MakeTrick()
        {
            return "Hold my paw, human!";
        }
    }
}
