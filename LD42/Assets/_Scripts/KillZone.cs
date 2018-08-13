using UnityEngine;

public class KillZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.Die(gameObject.name);
        }
    }
}
