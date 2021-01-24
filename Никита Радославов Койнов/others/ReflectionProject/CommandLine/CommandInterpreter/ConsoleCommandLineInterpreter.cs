namespace CommandLine.CommandInterpreter
{
    using System;

    public class ConsoleCommandLineInterpreter : CommandLineInterpreter
    {
        protected override void OutputCommandResult(string result)
        {
            Console.WriteLine(result);
        }

        protected override string ReadNextCommandLine()
        {
            return Console.ReadLine();
        }

        protected override void OutputWrongCommand(string output)
        {
            Console.WriteLine(output);
        }
    }
}
