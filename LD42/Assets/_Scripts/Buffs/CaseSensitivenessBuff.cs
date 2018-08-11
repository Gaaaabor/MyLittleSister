using UnityEngine;

public class CaseSensitivenessBuff : BuffBase
{
    public CaseSensitivenessBuff(float duration) : base(duration)
    {
        Name = "CaseSensitivenessBuff";
    }

    public override bool OnStart()
    {
        var startExecuted = base.OnStart();
        if (!startExecuted)
        {
            CommandHandler.Instance.IsCaseSensitive = true;
        }
        return startExecuted;
    }

    public override bool Apply()
    {
        if (!base.Apply())
        {
            return false;
        }

        Duration -= Time.deltaTime;
        return true;
    }

    public override bool OnEnd()
    {
        var endExecuted = base.OnEnd();
        if (!endExecuted)
        {
            CommandHandler.Instance.IsCaseSensitive = false;
        }
        return endExecuted;
    }
}