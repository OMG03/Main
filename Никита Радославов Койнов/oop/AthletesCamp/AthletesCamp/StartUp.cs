namespace AthletesCamp
{
    using System;
    using System.IO;
    using System.Text;

    public class StartUp
    {
        private const string ResidentInformationMessage = "Enter Valid Information for the Resident";
        private const string EGNMessage = "EGN: ";
        private const string FullNameMessage = "Full name: ";
        private const string HealthConditionMessage = "HealthCondition: ";
        private const string DaysOfResidenceMessage = "DaysOfResidence: ";

        private static string ResidentsCountMessage = "Enter the number of residents. Residents count: ";

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(ResidentsCountMessage);
                string answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    LoadDefaultData();
                    break;
                }

                if (int.TryParse(answer, out int residentsCount)
                    && residentsCount >= 5
                    && residentsCount <= 40)
                {
                    while (residentsCount-- > 0)
                    {
                        ReadResidentData();
                    }
                    break;
                }

                ResidentsCountMessage = "Enter the number (from 5 to 40) of residents. Residents count: ";
                ClearLastConsoleLine();
            }


            Console.WriteLine("Writing into File...");
            using (FileStream fileStream = File.Create(@"./../../../sport_persons.txt"))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8, 256);
                streamWriter.WriteLine("CAMP RESIDENTS");
                streamWriter.WriteLine();
                streamWriter.Flush();

                foreach (var resident in SportPerson.GetAllResidents())
                {
                    string line = resident.ToString();
                    Console.WriteLine(line);
                    streamWriter.WriteLine(line);
                    streamWriter.Flush();
                }
            }
        }

        private static void ReadResidentData()
        {
            Console.WriteLine(ResidentInformationMessage);
            string fullName;
            string egn;
            string healthCondition;
            string daysOfResidence;

            string fullNameMessage = FullNameMessage;
            while (true)
            {
                Console.Write(fullNameMessage);
                fullName = Console.ReadLine();

                if (SportPerson.IsValidFullName(fullName))
                {
                    break;
                }
                fullNameMessage = "Please enter Valid " + FullNameMessage;
            }

            string egnMessage = EGNMessage;
            while (true)
            {
                Console.Write(egnMessage);
                egn = Console.ReadLine();

                if (SportPerson.IsValidEGN(egn))
                {
                    break;
                }
                egnMessage = "Please enter Valid " + EGNMessage;
            }

            string healthConditionMessage = HealthConditionMessage;
            while (true)
            {
                Console.Write(healthConditionMessage);
                healthCondition = Console.ReadLine();

                if (SportPerson.IsValidHealthCondition(healthCondition))
                {
                    break;
                }
                healthConditionMessage = "Please enter Valid " + HealthConditionMessage;
            }


            string daysOfResidenceMessage = DaysOfResidenceMessage;
            while (true)
            {
                Console.Write(daysOfResidenceMessage);
                daysOfResidence = Console.ReadLine();

                if (SportPerson.IsValidDaysOfResidence(daysOfResidence))
                {
                    break;
                }
                daysOfResidenceMessage = "Please enter Valid " + DaysOfResidenceMessage;
            }

            SportPerson.AddResident(new SportPerson
            {
                FullName = fullName,
                EGN = egn,
                HealthCondition = healthCondition,
                DaysOfResidence = int.Parse(daysOfResidence)
            });

            Console.WriteLine();
        }

        private static void LoadDefaultData()
        {
            SportPerson.AddResident(new SportPerson
            {
                FullName = "Ivan Ivanov",
                EGN = "1234567890",
                HealthCondition = "Really Good",
                DaysOfResidence = 14
            });

            SportPerson.AddResident(new SportPerson
            {
                FullName = "Goshkoto Goshevski",
                EGN = "1234567891",
                HealthCondition = "Really Bad",
                DaysOfResidence = 7
            });

            SportPerson.AddResident(new SportPerson
            {
                FullName = "Peso Pesh",
                EGN = "1234567892",
                HealthCondition = "Really Good",
                DaysOfResidence = 20
            });

            SportPerson.AddResident(new SportPerson
            {
                FullName = "Sako San",
                EGN = "1234567893",
                HealthCondition = "Really Good",
                DaysOfResidence = 16
            });

            SportPerson.AddResident(new SportPerson
            {
                FullName = "Misho Mishev",
                EGN = "1234567894",
                HealthCondition = "Really Bad",
                DaysOfResidence = 7
            });
        }

        public static void ClearLastConsoleLine()
        {
            int lastLineCursor = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, lastLineCursor);
        }
    }
}
