using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public delegate void KingAttackedEventHandelr(object sender);

    public class King : Person
    {
        public KingAttackedEventHandelr Attacked { get; set; }

        public King(string name)
            : base(name)
        {
            this.Attacked += (s) => Console.WriteLine($"King {Name} is under attack!");
        }

        public override void OnAttacked(object sender = null)
        {
            this.Attacked.Invoke(this);
        }
    }
}
