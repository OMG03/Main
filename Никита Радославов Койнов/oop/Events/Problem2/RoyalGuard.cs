using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public class RoyalGuard : Person
    {
        public RoyalGuard(string name)
            : base(name)
        {

        }

        public override void OnAttacked(object sender)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }
    }
}
