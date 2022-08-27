using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;
using CommandPattern.Messages;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];
            string[] arguments = cmdArgs
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly?
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{command}Command"
                && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (commandType == null)
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.InvalidCommandType, $"{command}Command"));
            }

            object commandInstance = Activator.CreateInstance(commandType);

            MethodInfo method = commandType.GetMethod("Execute");

            string result = (string)method.Invoke(commandInstance, new object[] { arguments });

            return result;
        }
    }
}
