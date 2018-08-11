using Assets._Scripts.Commands;
using System;
using System.Collections.Generic;

namespace Assets._Scripts
{
    public class CommandHandler
    {
        public const char WHITESPACE = ' ';

        public volatile static object _lock = new object();
        public static CommandHandler _instance;
        public static CommandHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CommandHandler();
                        }
                    }
                }

                return _instance;
            }
        }

        public List<CommandBase> Commands { get; private set; }

        public bool IsCaseSensitive;

        private CommandHandler()
        {
            Commands = new List<CommandBase>
            {
                new DestroyCommand(),
                new OpenCommand(),
                new ResetCheckPointCommand()
            };
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
