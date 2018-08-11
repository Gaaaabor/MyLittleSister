using Assets._Scripts.Commands;
using System;
using System.Collections.Generic;

namespace Assets._Scripts
{
    public class CommandHandler
    {
        public const char WHITESPACE = ' ';

        public List<CommandBase> Commands;

        public bool IsCaseSensitive;

        public void RegisterCommand(CommandBase command)
        {
            Commands.Add(command);
        }

        public void TryExecuteCommand(string commandToExecute)
        {
            var stringComparison = IsCaseSensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            foreach (var command in Commands)
            {
                if (string.Equals(command.CommandText, commandToExecute, stringComparison))
                {
                    var parameters = commandToExecute
                        .Replace(command.CommandText, string.Empty)
                        .Split(WHITESPACE);

                    command.Execute(parameters);
                }
            }
        }
    }
}
