using UnityEngine;

[ExecuteInEditMode]
public class RandomRotation : MonoBehaviour
{
    public float MinScale = 2.5f;
    public float MaxScale = 4f;
    public Vector3 RotationOffset;

    void Start()
    {
#if UNITY_EDITOR
        Vector3 rotation = new Vector3(0+RotationOffset.x, Random.Range(0, 360) + RotationOffset.y,0 + RotationOffset.z);
        this.transform.rotation = Quaternion.Euler(rotation);
        float scale = Random.Range(MinScale, MaxScale);
        this.transform.localScale = new Vector3(scale, scale, scale);
        DestroyImmediate(this);
#endif
    }
}