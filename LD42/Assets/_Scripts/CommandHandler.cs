using Assets._Scripts.Commands;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts
{
    public class CommandHandler
    {
        public const char WHITESPACE = ' ';

        #region //Singleton
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
        #endregion //Singleton

        public List<CommandBase> Commands { get; private set; }

        public bool IsCaseSensitive;

        private CommandHandler()
        {
            Commands = new List<CommandBase>
            {
                new DestroyCommand(),
                new ResetCheckPointCommand(),
                new OpenCommand(),
                new ActivateCommand()
            };
        }

        //IDEA: paypal fun

        public bool TryExecuteCommand(string commandToExecute)
        {
            var stringComparison = IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            CommandBase foundCommand = null;
            foreach (var command in Commands)
            {
                if (!command.CommandText.Equals(commandToExecute, stringComparison))
                {
                    continue;
                }

                foundCommand = command;
                break;
            }

            if (foundCommand == null)
            {
                Debug.Log(string.Format("Incorrect command ({0})!", commandToExecute));
                return false;
            }

            var parameters = commandToExecute
                .Replace(foundCommand.CommandText, string.Empty)
                .Split(WHITESPACE);

            foundCommand.Execute(parameters);

            return true;
        }
    }
}
