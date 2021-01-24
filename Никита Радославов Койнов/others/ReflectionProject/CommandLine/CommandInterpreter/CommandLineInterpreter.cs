namespace CommandLine.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using CommandLine.CommandInterpreter.Contracts;
    using CommandLine.Commands;

    public abstract class CommandLineInterpreter : ICommandLineInterpreter
    {
        private IEnumerable<Type> commandTypes;

        protected abstract string ReadNextCommandLine();

        protected abstract void OutputCommandResult(string result);

        protected abstract void OutputWrongCommand(string output);

        public void StartListening()
        {
            this.LoadCommands();

            while (true)
            {
                // Reads Command Line
                string[] commandLine = ReadNextCommandLine().Split("--");

                // Finds the correct Command Type
                string commandName = commandLine[0].ToLower().Trim();
                var commandType = this.commandTypes.FirstOrDefault(t => t.Name.ToLower().Equals($"{commandName}command"));

                if (commandType is null)
                {
                    this.OutputWrongCommand($"The command {commandType} does not exists!");
                    continue;
                }

                // Craetes the Command Instance
                var command = (ICommand)Activator.CreateInstance(commandType);
                var commandFields = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                // Loads commad parameters
                for (int i = 1; i < commandLine.Length; i++)
                {
                    // Gets current parameter and value (format: --[parameter] [value])
                    var parameterAndValue = commandLine[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parameterAndValue.Length != 2)
                    {
                        continue;
                    }

                    var parameter = parameterAndValue[0];
                    var value = parameterAndValue[1];

                    // Loads field data if filed exists
                    var currentField = commandFields.FirstOrDefault(x => x.Name.ToLower().Equals(parameter.ToLower()));
                    if (currentField != null)
                    {
                        currentField.SetValue(command, Convert.ChangeType(value, currentField.FieldType));
                    }
                }

                try
                {
                    this.OutputCommandResult(command.Execute());
                }
                catch (Exception ex)
                {
                    this.OutputWrongCommand(ex.Message);
                }
            }
        }

        private void LoadCommands()
        {
            this.commandTypes = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.IsClass && t.Name.ToLower().Contains("command") && typeof(ICommand).IsAssignableFrom(t));
        }
    }
}
