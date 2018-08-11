using Assets._Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets._Scripts
{
    public class CommandHandler
    {
        public const string WHITESPACE = " ";

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
                new DisableCommand(),
                new EnableCommand(),
                new RestartCommand(),
                new ActivateCommand(),
                new SpeedCommand()
            };
        }

        //IDEA: paypal fun

        public bool TryExecuteCommand(string commandToExecute)
        {
            if (string.IsNullOrEmpty(commandToExecute))
            {
                return false;
            }

            commandToExecute = removeWhiteSpaceDuplications(commandToExecute);

            var commandPart = commandToExecute.Contains(WHITESPACE)
                ? commandToExecute.Split(new[] { WHITESPACE }, StringSplitOptions.RemoveEmptyEntries)[0]
                : commandToExecute;

            var stringComparison = IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            CommandBase foundCommand = null;
            foreach (var command in Commands)
            {
                if (!command.CommandText.Equals(commandPart, stringComparison))
                {
                    continue;
                }

                foundCommand = command;
                break;
            }

            if (foundCommand == null)
            {
                Debug.Log(string.Format("Incorrect command ({0})!", commandPart));
                return false;
            }

            var parameters = commandToExecute
                .Replace(foundCommand.CommandText, string.Empty)
                .Split(new[] { WHITESPACE }, StringSplitOptions.RemoveEmptyEntries);

            foundCommand.Execute(parameters);

            return true;
        }

        private string removeWhiteSpaceDuplications(string commandToExecute)
        {
            var builder = new StringBuilder();
            var previousIsWhitespace = false;
            for (var i = 0; i < commandToExecute.Length; i++)
            {
                if (char.IsWhiteSpace(commandToExecute[i]))
                {
                    if (previousIsWhitespace)
                    {
                        continue;
                    }

                    previousIsWhitespace = true;
                }
                else
                {
                    previousIsWhitespace = false;
                }

                builder.Append(commandToExecute[i]);
            }

            return builder.ToString();
        }
    }
}
