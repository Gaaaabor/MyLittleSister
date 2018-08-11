using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Vector3 _lookpos;

    private void Start()
    {
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }

    void Update()
    {
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }

    public void LookAtNow()
    {
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }
}
