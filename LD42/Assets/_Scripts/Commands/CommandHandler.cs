using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
                new CheatModeCommand(),
                new DestroyCommand(),
                new DisableCommand(),
                new EnableCommand(),
                new RestartCommand(),
                new ActivateCommand(),
                new SpeedCommand()
            };
    }

    //IDEA: paypal fun

    public CommandResult TryExecuteCommand(string commandToExecute)
    {
        if (string.IsNullOrEmpty(commandToExecute))
        {
            return new CommandResult(false);
        }

        commandToExecute = RemoveWhiteSpaceDuplications(commandToExecute);

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
            var incorrectCommandResult = new CommandResult(string.Format("Incorrect command ({0})!", commandToExecute), false);
            Debug.Log(incorrectCommandResult);
            return incorrectCommandResult;
        }

        var parameters = commandToExecute
            .Substring(commandPart.Length, commandToExecute.Length - commandPart.Length)
            .Split(new[] { WHITESPACE }, StringSplitOptions.RemoveEmptyEntries);

        var foundCommandResult = foundCommand.Execute(parameters);

        ExecuteWaitForCommands(foundCommand, parameters, foundCommandResult);

        return foundCommandResult;
    }

    private void ExecuteWaitForCommands(CommandBase foundCommand, string[] parameters, CommandResult foundCommandResult)
    {
        if (foundCommandResult == null || !foundCommandResult)
        {
            return;
        }

        var waitForCommands = Resources.FindObjectsOfTypeAll(typeof(WaitForCommand)).ToList();
        foreach (WaitForCommand waitForCommand in waitForCommands)
        {
            waitForCommand.OnCommand(foundCommand.CommandText, parameters);
        }
    }

    private string RemoveWhiteSpaceDuplications(string commandToExecute)
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