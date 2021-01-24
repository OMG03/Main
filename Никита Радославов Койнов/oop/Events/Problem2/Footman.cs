using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public class Footman : Person
    {
        public Footman(string name)
            : base(name)
        {

        }

        public override void OnAttacked(object sender)
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }
    }
}
