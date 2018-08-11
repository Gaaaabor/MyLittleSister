using System;
using UnityEngine;

public class TimeBuff : BuffBase
{
    public TimeBuff(float scale, float duration) : base(duration)
    {
        Time.timeScale = Math.Min(scale, 1);
        Name = "TimeBuff";
    }

    public override bool Apply()
    {
        if (!base.Apply())
        {
            return false;
        }

        Duration -= (1 - Time.timeScale) * Time.unscaledDeltaTime;
        return true;
    }

    public override bool OnEnd()
    {
        var endExecuted = base.OnEnd();
        if (!endExecuted)
        {
            Time.timeScale = 1;
        }
        return endExecuted;
    }
}