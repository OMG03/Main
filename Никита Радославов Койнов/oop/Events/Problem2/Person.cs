using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2
{
    public abstract class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void OnAttacked(object sender);
    }
}
