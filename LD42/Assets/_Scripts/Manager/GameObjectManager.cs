using System;
using System.Collections;
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

    public GameObject ErrorPref;
    public GameObject CommandPref;
    public Transform Parent;
    public ScrollRect ScrollRect;
    public float HideTime;
    public AnimationCurve HideAnimCurve;
    public CanvasGroup CanvasGroup;

    public override void Awake()
    {
        base.Awake();
        CommandField.gameObject.SetActive(false);
        ErrorPref.SetActive(false);
        CommandPref.SetActive(false);
        CanvasGroup.alpha = 0;
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
        if(!string.IsNullOrEmpty(CommandField.text))
        {
            CanvasGroup.alpha = 1;
            StopAllCoroutines();
            StartCoroutine(HideRect());            

            var result = CommandHandler.Instance.TryExecuteCommand(CommandField.text);

            var pref = result 
                ? CommandPref 
                : ErrorPref;

            var go = Instantiate(pref, Parent) as GameObject;            
            go.SetActive(true);
            go.GetComponentInChildren<Text>().text = result.Message;
        }

        CommandField.gameObject.SetActive(true);
        CommandField.ActivateInputField();
        CommandField.Select();

        CommandField.text = string.Empty;
        Invoke("FixRect", 0.1f);
    }

    private IEnumerator HideRect()
    {
        var currentRot = transform.localRotation;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / HideTime;

            CanvasGroup.alpha = HideAnimCurve.Evaluate(t); ;

            yield return null;
        }
        CanvasGroup.alpha = 0;
    }

    public void FixRect()
    {
        ScrollRect.normalizedPosition = new Vector2(0, 0);
    }

    public void RegisterObject(ManagedGameObject managedGameObject)
    {
        ManagedObjects.Add(managedGameObject);
    }

    public IEnumerable<ManagedGameObject> GetManagedGameObjects(string name)
    {
        if (string.IsNullOrEmpty(name) || ManagedObjects == null)
        {
            return null;
        }

        return ManagedObjects.Where(x => x.ManagedName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
