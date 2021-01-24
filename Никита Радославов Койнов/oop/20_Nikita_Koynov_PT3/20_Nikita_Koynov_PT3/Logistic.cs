namespace _20_Nikita_Koynov_PT3
{
    public class Logistic
    {
        public string FullName { get; set; }

        public string Position { get; set; }

        public int WorkExperienceInYears { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{FullName} ({Position}) - {WorkExperienceInYears} years [{Salary}]";
        }
    }
}
