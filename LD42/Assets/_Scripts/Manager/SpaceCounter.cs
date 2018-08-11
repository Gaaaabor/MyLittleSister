using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceCounter : SingletonBase<SpaceCounter>
{
    public Animator SpaceAnim;

    public int SpaceCount
    {
        get
        {
            return _spaceCount;
        }
        set
        {
            _spaceCount = value;
            SpaceCounterText.text = _spaceCount.ToString();
        }
    }

    private int _spaceCount;

    public Text SpaceCounterText;

    public override void Awake()
    {
        base.Awake();
        SpaceCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceCount++;
            SpaceAnim.SetTrigger("Animate");
        }
    }
}
