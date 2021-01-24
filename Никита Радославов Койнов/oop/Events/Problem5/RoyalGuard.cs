using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5
{
    public class RoyalGuard : Person
    {
        private const int RoyalGuardLives = 3;

        public RoyalGuard(string name)
            : base(name, RoyalGuardLives)
        {

        }

        public override void OnAttacked(object sender)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }
    }
}
