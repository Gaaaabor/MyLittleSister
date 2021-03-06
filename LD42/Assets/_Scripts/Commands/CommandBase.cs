﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CommandBase
{
    public string ShortHand { get; protected set; }
    public string CommandText { get; protected set; }
    public int ParameterCount { get; protected set; }

    public virtual CommandResult Execute(string[] parameters)
    {
        if (!IsParameterCountValid(parameters))
        {
            var commandResult = new CommandResult(string.Format("Incorrect number of parameters {0}/{1} for command ({2})", parameters == null ? 0 : parameters.Length, ParameterCount, CommandText), false);
            Debug.Log(commandResult);
            return commandResult;
        }

        return new CommandResult();
    }

    private bool IsParameterCountValid(string[] parameters)
    {
        return parameters != null && ParameterCount == parameters.Length;
    }

    protected IEnumerable<ManagedGameObject> FindManagedGameObjects(string name)
    {
        var managedGameObjects = GameObjectManager.Instance.GetManagedGameObjects(name);
        if (managedGameObjects == null || !managedGameObjects.Any())
        {
            return managedGameObjects;
        }

        return managedGameObjects.Where(x => !string.IsNullOrEmpty(x.ManagedName) && x.ManagedName.Equals(name, CommandHandler.ComparisonMode)).ToList();
    }
}