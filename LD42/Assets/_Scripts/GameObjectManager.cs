using Assets._Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectManager : MonoBehaviour
{
    private bool _inCommand;

    public List<ManagedGameObject> ManagedObjects;
    public InputField CommandField;
    public KeyCode CommandKey;

    private void Awake()
    {
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
}
