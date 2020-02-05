using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GManager gameManager;
    public Transform frontHitDetector;
    public float radius = 0.1f;
    public LayerMask obsMask;
    bool hitFront;

    public void OnCollisionEnter(Collision collisionInfo)
    {
        /* https://answers.unity.com/questions/473871/detect-side-of-collision.html */

        if (collisionInfo.collider.tag == "Obstacle" && !gameManager.is_Invincible)
        {
            //Debug.Log("We hit an obstacle!");

            Vector3 hit = collisionInfo.contacts[0].normal;

            //float angle1 = Vector3.Angle(hit, Vector3.forward);

            float angle2 = Vector3.Angle(hit, Vector3.up);

            if (hitFront) //front
            {
                Debug.Log("Hit front");
                movement.enabled = false;
                FindObjectOfType<GManager>().EndGame();
            }
            if (Mathf.Approximately(angle2, 180)) //top
            {
                Debug.Log("Hit top");
                movement.enabled = false;
                FindObjectOfType<GManager>().EndGame();
            }
            

        }
    }

    private void FixedUpdate()
    {
        hitFront = Physics.CheckSphere(frontHitDetector.position, radius, obsMask);
    }
}
