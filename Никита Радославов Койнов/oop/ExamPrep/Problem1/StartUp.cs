using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem1
{
    public class StartUp
    {
        public const int MIN_INPUT_COUNT = 1;
        public const int MAX_INPUT_COUNT = 50;

        private static List<Car> cars;

        public static void Main(string[] args)
        {
            int inputCount = GetCountInput(MIN_INPUT_COUNT, MAX_INPUT_COUNT);

            cars = new List<Car>(inputCount);

            LoadData(inputCount);

            DisplayData();

            SaveRandomCarsInFile(MIN_INPUT_COUNT);

            DisplayAndSavePowerfulCars();

            DisplayAndSaveOrderedCars();
        }

        private static void DisplayAndSaveOrderedCars()
        {
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open("../../../Output/sortprice.txt", FileMode.Create)))
            {
                Console.WriteLine();
                Console.WriteLine("Ordered Cars");
                streamWriter.WriteLine("Ordered Cars");
                int i = 1;
                foreach (var car in cars.OrderBy(c => c.Price))
                {
                    streamWriter.WriteLine(i + ". " + car.ToString());
                    Console.WriteLine(i + ". " + car.ToString());
                    i++;
                }
            }
        }

        private static void DisplayAndSavePowerfulCars()
        {
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open("../../../Output/power.txt", FileMode.Create)))
            {
                Console.WriteLine();
                Console.WriteLine("Cars with engine power grater than 184kW");
                streamWriter.WriteLine("Cars with engine power grater than 184kW");
                int i = 1;
                foreach (var car in cars.Where(c => c.EnginePowerkW > 184))
                {
                    streamWriter.WriteLine(i + ". " + car.ToString());
                    Console.WriteLine(i + ". " + car.ToString());
                    i++;
                }
            }
        }

        private static void SaveRandomCarsInFile(int min)
        {
            Random random = new Random();

            int carsToSave = random.Next(min, cars.Count);
            List<int> savedCarIndexes = new List<int>(carsToSave);

            Console.WriteLine();
            Console.WriteLine("Writing random cars to cars.txt...");
            using (StreamWriter streamWriter = new StreamWriter(
                File.Open("../../../Output/cars.txt", FileMode.Create)))
            {
                streamWriter.WriteLine("Random Cars");
                for (int i = 0; i < carsToSave; i++)
                {
                    int randomCarIndex = -1;
                    do
                    {
                        randomCarIndex = random.Next(0, cars.Count);
                    } while (savedCarIndexes.Contains(randomCarIndex));

                    savedCarIndexes.Add(randomCarIndex);

                    Car car = cars[randomCarIndex];

                    streamWriter.WriteLine(i + 1 + ". " + cars[i].ToString());
                }
            }
        }

        private static void DisplayData()
        {
            Console.WriteLine();
            Console.WriteLine("All Cars!");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + cars[i].ToString());
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
                Car car = GetCarInput(i + 1);
                cars.Add(car);
            }
        }

        private static Car GetCarInput(int carInex)
        {
            Console.WriteLine();
            Console.WriteLine($"Car {carInex}:");
            Car car = new Car();

            string makeAndModel = "";
            do
            {
                try
                {
                    Console.Write($"Enter make and mark: ");
                    makeAndModel = Console.ReadLine();
                }
                catch (Exception)
                {
                    makeAndModel = "";
                }
            } while (makeAndModel.Length > 30);

            int manufactureYear = 0;
            do
            {
                try
                {
                    Console.Write($"Enter manufacture year: ");
                    manufactureYear = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    manufactureYear = 0;
                }
            } while (manufactureYear < 1900 || manufactureYear > DateTime.Now.Year + 5);

            int enginePower = 0;
            do
            {
                try
                {
                    Console.Write($"Enter engine power in kW: ");
                    enginePower = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    enginePower = 0;
                }
            } while (enginePower <= 0);

            int price = 0;
            do
            {
                try
                {
                    Console.Write($"Enter price: ");
                    price = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    price = 0;
                }
            } while (price <= 0);

            car.MakeAndModel = makeAndModel;
            car.ManufactureYear = manufactureYear;
            car.EnginePowerkW = enginePower;
            car.Price = price;

            return car;
        }
    }
}
