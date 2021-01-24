using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace _20_Nikita_Koynov_PT3
{
    public class StartUp
    {
        private const bool IS_DEV = false;
        private const int MIN_INPUT_COUNT = 5;
        private const int MAX_INPUT_COUNT = 30;
        private const string OUTPUT_PATH = "../../../Output";
        private const string INPUT_MESSAGE = "Person {0}:";
        private const string ALL_DATA_MESSAGE = "All People!";
        private const string RANDOM_DATA_MESSAGE = "Random People!";
        private const string FILTERED_DATA_MESSAGE = "Filtered People!";
        private const string ORDERED_DATA_MESSAGE = "Ordered People!";

        private static List<Logistic> people;


        public static void Main(string[] args)
        {
            if (IS_DEV)
            {
                // Ако е в тестов режим програмата зарежда предварително зададени данни
                LoadPreSetData();
            }
            else
            {
                // Чете се от конзолата колко записа трябва да се прочетат и запишат
                int inputCount = GetCountInput(MIN_INPUT_COUNT, MAX_INPUT_COUNT);

                // Създава инстанция на колекцията за записване на данни
                people = new List<Logistic>(inputCount);

                // Започва четене и записване на данни
                LoadData(inputCount);
            }

            // Изписва записаната информация на конзолата
            DisplayData();

            // Записва произволна информация на конзолата
            SaveRandomDataInFile();

            // Изписва на конзолата и записва във файл всички хора, които имат заплата по голяма от 1500
            DisplayAndSave(
                fileName: "money.txt",
                dataMessage: FILTERED_DATA_MESSAGE,
                data: people.Where(x => x.Salary > 1500));

            // Изписва на конзолата и записва във файл всички хора, подредени по азбучен ред на имената
            DisplayAndSave(
                fileName: "sort_name.txt",
                dataMessage: ORDERED_DATA_MESSAGE,
                data: people.OrderBy(x => x.FullName));

            // Изписва на конзолата и записва във файл всички хора, които имат стаж по голям от 20 години и позиция "Шофьор" или "Driver"
            DisplayAndSave(
                fileName: "high_driver.txt",
                dataMessage: FILTERED_DATA_MESSAGE,
                data: people.Where(x => (x.Position.Equals("Шофьор") || x.Position.Equals("Driver"))
                                     && x.WorkExperienceInYears > 20));
        }

        private static void LoadPreSetData()
        {
            people = new List<Logistic>()
            {
                new Logistic
                {
                    FullName = "Ivan Toshev",
                    Position = "Boss",
                    Salary = 2000,
                    WorkExperienceInYears = 10
                },
                new Logistic
                {
                    FullName = "Gogo Toshev",
                    Position = "Manager",
                    Salary = 2000,
                    WorkExperienceInYears = 24
                },
                new Logistic
                {
                    FullName = "Tosho Toshev",
                    Position = "Manager",
                    Salary = 1900,
                    WorkExperienceInYears = 20
                },
                new Logistic
                {
                    FullName = "Pesho Toshev",
                    Position = "Шофьор",
                    Salary = 670,
                    WorkExperienceInYears = 30
                },
                new Logistic
                {
                    FullName = "Sasho Toshev",
                    Position = "Шофьор",
                    Salary = 520,
                    WorkExperienceInYears = 25
                },
                new Logistic
                {
                    FullName = "Dimitur Toshev",
                    Position = "Шофьор",
                    Salary = 500,
                    WorkExperienceInYears = 6
                },
                new Logistic
                {
                    FullName = "Petur Toshev",
                    Position = "Trainee",
                    Salary = 0,
                    WorkExperienceInYears = 0
                },
            };
        }

        private static void DisplayAndSave(string fileName, string dataMessage, IEnumerable<Logistic> data)
        {
            // Отваря връзка към файл
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open($"{OUTPUT_PATH}/{fileName}", FileMode.Create)))
            {
                // Изписва информационно съобщение на конзолата
                Console.WriteLine();
                Console.WriteLine(dataMessage);

                // Изписва информационно съобщение във файл
                streamWriter.WriteLine(dataMessage);

                // Изписва инфорамцията за всеки от подадените хора
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
            string fileName = "logistic_name.txt";

            // Изписва инфорационно съобщение на конзолата
            Console.WriteLine();
            Console.WriteLine($"Writing random data to {fileName}...");

            Random random = new Random();
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open($"{OUTPUT_PATH}/{fileName}", FileMode.Create)))
            {
                // Изписва инфорационно съобщение във файла
                streamWriter.WriteLine(RANDOM_DATA_MESSAGE);

                int index = 1;
                foreach (var item in people)
                {
                    // Взима произволно число и взависимост от него се записва информация за човек
                    if (random.NextDouble() < 0.5)
                    {
                        streamWriter.WriteLine(index++ + ". " + item.ToString());
                    }
                }
            }
        }

        private static void DisplayData()
        {
            // Изписва цялата информация на конзолата 

            Console.WriteLine();
            Console.WriteLine(ALL_DATA_MESSAGE);
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + people[i].ToString());
            }
        }

        private static int GetCountInput(int min, int max)
        {
            // Чете число от конзолата, докато то не е между min и max

            Console.WriteLine("How many people do you want to input?");

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
                // Извиква метода за четене на информация за човек
                Logistic inputData = GetInputData(i + 1);

                // Записва прочетената информация
                people.Add(inputData);
            }
        }

        private static string ReadStringInput(string message, int minLength, int maxLenght)
        {
            // Изписва информационни съобщение и чете текст от конзолата, докато дължината му не е между minLength и maxLenght

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
            // Изписва информационни съобщение и чете цяло число от конзолата, докато то не е между minValue и maxValue

            int input = minValue - 1;
            do
            {
                Console.Write(message);
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    input = minValue - 1;
                }

            } while (input < minValue || input > maxValue);

            return input;
        }

        private static decimal ReadDecimalInput(string message, decimal minValue, decimal maxValue)
        {
            // Изписва информационни съобщение и чете число от конзолата, докато то не е между minValue и maxValue

            decimal input = minValue - 1;
            do
            {
                Console.Write(message);
                try
                {
                    Console.Write(message);
                    input = decimal.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    input = minValue - 1;
                }

            } while (input < minValue || input > maxValue);

            return input;
        }

        private static Logistic GetInputData(int index)
        {
            // Изписва информационно съобщение
            Console.WriteLine();
            Console.WriteLine(INPUT_MESSAGE, index);

            // Създава нов човек
            Logistic person = new Logistic();

            // Чете информация за човека
            person.FullName = ReadStringInput("Enter Full Name: ", 3, 30);
            person.Position = ReadStringInput("Enter Position: ", 3, 20);
            person.WorkExperienceInYears = ReadIntegerInput("Enter Work experience in years: ", 0, 100);
            person.Salary = ReadDecimalInput("Enter Salary: ", 0, 10000);

            return person;
        }
    }
}

