using UnityEngine.Events;

public class WaitForCheatMode : SingletonBase<WaitForCheatMode>
{
    public UnityEvent Event;

    public void CheatModeDone()
    {
        gameObject.SetActive(false);

        Event.Invoke();
        Destroy(this);
    }
}
