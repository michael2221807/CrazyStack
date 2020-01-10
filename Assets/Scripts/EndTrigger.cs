using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
