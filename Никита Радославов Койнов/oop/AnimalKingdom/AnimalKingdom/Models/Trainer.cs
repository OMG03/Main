using AnimalKingdom.Models.Contracts;

namespace AnimalKingdom.Models
{
    public class Trainer
    {
        public IAnimal Animal { get; set; }

        public Trainer(IAnimal animal)
        {
            Animal = animal;
        }

        public void Make()
        {
            this.Animal.Perform();
        }
    }
}
