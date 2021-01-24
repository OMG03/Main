namespace CommandLine.Commands
{
    using System;

    public class HelloCommand : ICommand
    {
        private string name;
        private int age;

        // type "hello --name [value] --age [value]" to execute this command
        public string Execute()
        {
            if (name is null)
            {
                throw new ArgumentException("Please provide name using --name [value]");
            }

            if (age != 0)
            {
                return $"Hello {name}. I know that you are {age} years old.";
            }

            return $"Hello {name}";
        }
    }
}
