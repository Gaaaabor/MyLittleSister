using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartDialog();
        }
    }

    private void StartDialog()
    {
        PlayerController.Instance.IdlePlayer();
    }
}
