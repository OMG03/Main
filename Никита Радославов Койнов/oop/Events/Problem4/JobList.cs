using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem4
{
    public class JobList
    {
        private List<Job> jobs = new List<Job>();

        public void AddJob(Job job)
        {
            this.jobs.Add(job);
            job.WhenFinished(() => this.jobs.Remove(job));
        }

        public void UpdateJobs()
        {
            // this.jobs.ForEach(j => j.Update());
            for (int i = 0; i < jobs.Count; i++)
            {
                this.jobs[i].Update();
            }
        }

        internal void PrintStatus()
        {
            this.jobs.ForEach(j => Console.WriteLine($"Job: {j.Name} Hours Remaining: {j.HoursOfWorkRequired}"));
        }
    }
}
