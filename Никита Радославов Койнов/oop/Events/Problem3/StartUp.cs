using System;

namespace Problem3
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var calculator = new Calculator();

            while (true)
            {
                var line = Console.ReadLine().Split();
                var arg1 = line[0];

                if (arg1.Equals("End"))
                {
                    break;
                }

                var arg2 = line[1];

                if (arg1.Equals("mode"))
                {
                    switch (arg2)
                    {
                        case "+":
                            calculator.ChangeStrategy((f, s) => f + s);
                            break;
                        case "-":
                            calculator.ChangeStrategy((f, s) => f - s);
                            break;
                        case "*":
                            calculator.ChangeStrategy((f, s) => f * s);
                            break;
                        case "/":
                            calculator.ChangeStrategy((f, s) => f / s);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(calculator.PerformCalculation(int.Parse(arg1), int.Parse(arg2)));
                }
            }
        }
    }
}
