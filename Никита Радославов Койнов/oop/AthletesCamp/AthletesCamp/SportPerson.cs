namespace AthletesCamp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SportPerson
    {
        private static ICollection<SportPerson> residents = new List<SportPerson>();

        public string FullName { get; set; }

        public string EGN { get; set; }

        public string HealthCondition { get; set; }

        public int DaysOfResidence { get; set; }

        public override string ToString()
        {
            int maxFullNameLength = residents.Max(x => x.FullName.Length);
            int maxDaysLength = residents.Max(x => x.DaysOfResidence.ToString().Length);
            
            string messageFormat = "{0}" + 
                new string(' ', maxFullNameLength - this.FullName.Length) + 
                " ({1}) - " + 
                new string(' ', maxDaysLength - this.DaysOfResidence.ToString().Length) + 
                "{2} days | {3} condition";

            return string.Format(messageFormat,
                this.FullName,
                this.EGN,
                this.DaysOfResidence,
                this.HealthCondition);
        }

        public static void AddResident(SportPerson resident)
        {
            if (!IsValidResident(resident))
            {
                throw new ArgumentException("Invalid Resident!");
            }

            residents.Add(resident);
        }

        public static IReadOnlyCollection<SportPerson> GetAllResidents()
        {
            return residents.ToList().AsReadOnly();
        }

        public static bool IsValidResident(SportPerson resident)
        {
            return resident != null
                && IsValidFullName(resident.FullName)
                && IsValidEGN(resident.EGN)
                && IsValidHealthCondition(resident.HealthCondition)
                && IsValidDaysOfResidence(resident.DaysOfResidence);
        }

        public static bool IsValidFullName(string fullName)
        {
            return fullName.Length <= 30;
        }

        public static bool IsValidEGN(string egn)
        {
            return egn.Length == 10;
        }

        public static bool IsValidHealthCondition(string healthCondition)
        {
            return healthCondition.Length <= 35;
        }

        public static bool IsValidDaysOfResidence(int daysOfResidence)
        {
            return daysOfResidence > 0;
        }

        public static bool IsValidDaysOfResidence(string daysOfResidence)
        {
            return int.TryParse(daysOfResidence, out int result)
                && IsValidDaysOfResidence(result);
        }
    }
}
