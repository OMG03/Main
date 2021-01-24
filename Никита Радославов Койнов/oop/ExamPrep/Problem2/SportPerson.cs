namespace Problem2
{
    public class SportPerson
    {
        public string FullName { get; set; } // todo not loger than 30 characters

        public string Egn { get; set; }

        public int ResidenceDays { get; set; }

        public string HealthCondition { get; set; } // todo not longer than 35 characters

        public override string ToString()
        {
            return $"{FullName} ({Egn}) - {ResidenceDays} days [{HealthCondition}]";
        }
    }
}
