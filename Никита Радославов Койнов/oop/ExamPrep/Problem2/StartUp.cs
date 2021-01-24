using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem2
{
    public class StartUp
    {
        private const bool IS_DEV = true;
        private const int MIN_INPUT_COUNT = 5;
        private const int MAX_INPUT_COUNT = 50;
        private const string OUTPUT_PATH = "../../../Output";
        private const string INPUT_MESSAGE = "Person {0}:";
        private const string ALL_DATA_MESSAGE = "All People!";
        private const string RANDOM_DATA_MESSAGE = "Random People!";
        private const string FILTERED_DATA_MESSAGE = "Filtered People!";
        private const string ORDERED_DATA_MESSAGE = "Ordered People!";

        private static List<SportPerson> people;


        public static void Main(string[] args)
        {
            if (IS_DEV)
            {
                LoadPreSetData();
            }
            else
            {
                int inputCount = GetCountInput(MIN_INPUT_COUNT, MAX_INPUT_COUNT);
                people = new List<SportPerson>(inputCount);
                LoadData(inputCount);
            }

            DisplayData();

            SaveRandomDataInFile();

            // Filltered Data
            DisplayAndSave(
                fileName: "days30.txt",
                dataMessage: FILTERED_DATA_MESSAGE,
                data: people.Where(x => x.ResidenceDays > 30));

            // Ordered Data
            DisplayAndSave(
                fileName: "sort_name.txt",
                dataMessage: ORDERED_DATA_MESSAGE,
                data: people.OrderBy(x => x.FullName));
        }

        private static void LoadPreSetData()
        {
            people = new List<SportPerson>()
            {
                new SportPerson
                {
                    FullName = "Ivan Toshev",
                    Egn = "1234567890",
                    HealthCondition = "Good",
                    ResidenceDays = 60
                },
                new SportPerson
                {
                    FullName = "Gogo Toshev",
                    Egn = "12324243240",
                    HealthCondition = "Very Good",
                    ResidenceDays = 55
                },
                new SportPerson
                {
                    FullName = "Tosho Toshev",
                    Egn = "2424567890",
                    HealthCondition = "Bad",
                    ResidenceDays = 13
                },
                new SportPerson
                {
                    FullName = "Pesho Toshev",
                    Egn = "2343434390",
                    HealthCondition = "Bad",
                    ResidenceDays = 14
                },
                new SportPerson
                {
                    FullName = "Sasho Toshev",
                    Egn = "1234344890",
                    HealthCondition = "Very Good",
                    ResidenceDays = 45
                },
                new SportPerson
                {
                    FullName = "Dimitur Toshev",
                    Egn = "1234434890",
                    HealthCondition = "Good",
                    ResidenceDays = 16
                },
                new SportPerson
                {
                    FullName = "Petur Toshev",
                    Egn = "1234555890",
                    HealthCondition = "Good",
                    ResidenceDays = 17
                },
            };
        }

        private static void DisplayAndSave(string fileName, string dataMessage, IEnumerable<SportPerson> data)
        {
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open($"{OUTPUT_PATH}/{fileName}", FileMode.Create)))
            {
                Console.WriteLine();
                Console.WriteLine(dataMessage);

                streamWriter.WriteLine(dataMessage);

                int index = 1;
                foreach (var item in data)
                {
                    streamWriter.WriteLine(index + ". " + item.ToString());
                    Console.WriteLine(index + ". " + item.ToString());
                    index++;
                }
            }
        }

        private static void SaveRandomDataInFile()
        {
            string fileName = "sport_persons.txt";

            Console.WriteLine();
            Console.WriteLine($"Writing random data to {fileName}...");

            Random random = new Random();
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open($"{OUTPUT_PATH}/{fileName}", FileMode.Create)))
            {
                streamWriter.WriteLine(RANDOM_DATA_MESSAGE);

                int index = 1;
                foreach (var item in people)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        streamWriter.WriteLine(index++ + ". " + item.ToString());
                    }
                }
            }
        }

        private static void DisplayData()
        {
            Console.WriteLine();
            Console.WriteLine(ALL_DATA_MESSAGE);
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + people[i].ToString());
            }
        }

        private static int GetCountInput(int min, int max)
        {
            Console.WriteLine("How many cars do you want to input?");

            int inputCount = min - 1;
            do
            {
                try
                {
                    Console.Write($"Enter a number between {min} and {max}: ");
                    inputCount = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    inputCount = min - 1;
                }
            } while (inputCount < min || inputCount > max);

            return inputCount;
        }

        private static void LoadData(int inputCount)
        {
            for (int i = 0; i < inputCount; i++)
            {
                SportPerson inputData = GetInputData(i + 1);
                people.Add(inputData);
            }
        }

        private static string ReadStringInput(string message, int minLength, int maxLenght)
        {
            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();

            } while (input.Length < minLength || input.Length > maxLenght);

            return input;
        }

        private static int ReadIntegerInput(string message, int minValue, int maxValue)
        {
            int input = minValue - 1;
            do
            {
                Console.Write(message);
                try
                {
                    Console.Write(message);
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    input = minValue - 1;
                }

            } while (input < minValue || input > maxValue);

            return input;
        }

        private static SportPerson GetInputData(int index)
        {
            Console.WriteLine();
            Console.WriteLine(INPUT_MESSAGE, index);

            SportPerson person = new SportPerson();

            person.FullName = ReadStringInput("Enter Full Name: ", 3, 30);
            person.Egn = ReadStringInput("Enter EGN: ", 10, 10);
            person.HealthCondition = ReadStringInput("Enter Health Condition: ", 3, 35);
            person.ResidenceDays = ReadIntegerInput("Enter Residence Days: ", 1, 100);

            return person;
        }
    }
}
