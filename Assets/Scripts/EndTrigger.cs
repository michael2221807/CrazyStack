using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GManager gameManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gameManager.CompleteLevel();
        }
    }
}
