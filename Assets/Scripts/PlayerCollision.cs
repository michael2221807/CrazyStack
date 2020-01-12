using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    public GManager gameManager;

    public void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log(collisionInfo.collider.name);

        if (collisionInfo.collider.tag == "Obstacle" && !gameManager.is_Invincible)
        {
            Debug.Log("We hit an obstacle!");
            movement.enabled = false;
            FindObjectOfType<GManager>().EndGame();

        }
    }
}
