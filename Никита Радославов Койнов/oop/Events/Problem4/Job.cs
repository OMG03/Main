using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4
{
    public delegate void JobFinished();

    public class Job
    {
        private Employee employee;
        private int hoursOfWorkRequired;
        private event JobFinished jobFinished;

        public string Name { get; set; }

        public int HoursOfWorkRequired
        {
            get => hoursOfWorkRequired;
            set
            {
                if (value <= 0)
                {
                    hoursOfWorkRequired = 0;
                    Console.WriteLine($"Job {Name} done!");
                    this.OnJobFinished();
                }
                else
                {
                    hoursOfWorkRequired = value;
                }
            }
        }

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public void Update()
        {
            this.HoursOfWorkRequired -= employee.WorkingWeekHours;
        }

        public void WhenFinished(JobFinished finished)
        {
            this.jobFinished += finished;
        }

        private void OnJobFinished()
        {
            if (this.jobFinished != null)
            {
                this.jobFinished.Invoke();
            }
        }
    }
}
