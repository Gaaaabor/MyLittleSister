using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectManager : SingletonBase<GameObjectManager>
{
    private bool _inCommand;

    public List<ManagedGameObject> ManagedObjects;
    public InputField CommandField;
    public KeyCode CommandKey;

    public override void Awake()
    {
        base.Awake();
        CommandField.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(CommandKey))
        {
            if (_inCommand)
            {
                StopCommand();
            }
            else
            {
                StartCommand();
            }
        }
    }

    private void StartCommand()
    {
        _inCommand = true;
        CommandField.gameObject.SetActive(true);
        CommandField.ActivateInputField();
        CommandField.Select();
    }

    private void StopCommand()
    {
        CommandHandler.Instance.TryExecuteCommand(CommandField.text);
        _inCommand = false;
        CommandField.gameObject.SetActive(false);
        CommandField.text = string.Empty;
    }

    public void RegisterObject(ManagedGameObject managedGameObject)
    {
        ManagedObjects.Add(managedGameObject);
    }

    public ManagedGameObject GetManagedGameObject(string name)
    {
        if (string.IsNullOrEmpty(name) || ManagedObjects == null)
        {
            return null;
        }

        return ManagedObjects.FirstOrDefault(x => x.ManagedName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
