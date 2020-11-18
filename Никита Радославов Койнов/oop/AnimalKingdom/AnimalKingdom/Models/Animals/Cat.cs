namespace AnimalKingdom.Models.Animals
{
    class Cat : Animal
    {
        public Cat(int age) 
            : base(age)
        {
        }

        public override string MakeNoise()
        {
            return "Meow!";
        }

        public override string MakeTrick()
        {
            return "No trick for you! I'm too lazy!";
        }
    }
}
