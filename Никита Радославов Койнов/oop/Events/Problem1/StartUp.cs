using System;

namespace Problem1
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dispacher = new Dispatcher();
            var handler = new Handler();

            dispacher.NameChange = handler.OnDispatcherNameChange; // swap = to += to keep all other subs

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                dispacher.Name = name;
            }
        }
    }
}
