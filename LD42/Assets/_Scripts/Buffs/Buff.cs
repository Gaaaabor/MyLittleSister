public abstract class BuffBase
{
    private bool _startExecuted;
    private bool _endExecuted;

    public string Name { get; protected set; }
    public float Duration { get; set; }


    public bool IsExpired { get; set; }

    private BuffBase()
    { }

    public BuffBase(float duration)
    {
        Duration = duration;
    }

    public virtual bool OnStart()
    {
        if (_startExecuted)
        {
            return true;
        }

        _startExecuted = true;

        return false;
    }

    public virtual bool Apply()
    {
        if (IsExpired)
        {
            return false;
        }

        if (Duration <= 0)
        {
            IsExpired = true;
        }

        return true;
    }

    public virtual bool OnEnd()
    {
        if (_endExecuted || !IsExpired)
        {
            return false;
        }

        _endExecuted = true;
        return true;
    }
}