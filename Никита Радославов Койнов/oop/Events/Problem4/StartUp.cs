using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            JobList jobs = new JobList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("End"))
                {
                    break;
                }

                var arguments = line.Split();
                var command = arguments[0];

                switch (command)
                {
                    case "Job":
                        jobs.AddJob(new Job(arguments[1], int.Parse(arguments[2]), employees.First(e => e.Name.Equals(arguments[3]))));
                        break;
                    case "StandartEmployee":
                        employees.Add(new StandartEmployee(arguments[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(arguments[1]));
                        break;
                    case "Pass":
                        jobs.UpdateJobs();
                        break;
                    case "Status":
                        jobs.PrintStatus();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
