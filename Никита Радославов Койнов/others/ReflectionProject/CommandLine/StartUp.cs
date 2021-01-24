namespace CommandLine
{
    using CommandLine.CommandInterpreter.Contracts;
    using CommandLine.CommandInterpreter;

    public class StartUp
    {
        private static readonly ICommandLineInterpreter commandLineInterpreter = new ConsoleCommandLineInterpreter();

        public static void Main(string[] args)
        {
            commandLineInterpreter.StartListening();
        }
    }
}
