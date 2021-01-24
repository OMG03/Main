using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4
{
    public abstract class Employee
    {
        protected Employee(string name, int workingWeekHours)
        {
            Name = name;
            WorkingWeekHours = workingWeekHours;
        }

        public string Name { get; set; }

        public int WorkingWeekHours { get; set; }
    }
}
