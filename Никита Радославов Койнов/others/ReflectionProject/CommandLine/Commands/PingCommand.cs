namespace CommandLine.Commands
{
    public class PingCommand : ICommand
    {
        // type "ping" to execute this command
        public string Execute()
        {
            return "Pong!";
        }
    }
}
