using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5
{
    public class Footman : Person
    {
        private const int FootmanLives = 2;

        public Footman(string name)
            : base(name, FootmanLives)
        {

        }

        public override void OnAttacked(object sender)
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }
    }
}
