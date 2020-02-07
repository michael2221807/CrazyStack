using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extendBlockMovement : MonoBehaviour
{
    public Rigidbody player;
    public Rigidbody extendBlock;

    public float v = 25f;

    public float down = -0.3f;


    // Start is called before the first frame update
    void Start()
    {
        extendBlock.velocity = player.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerPosition = player.transform.position.z;
        float extendBlockPosition = extendBlock.transform.position.z;
        //extendBlock.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        Vector3 ve = player.velocity.normalized;
        ve.x = 0f;
        ve.y = down;
        ve *= v;
        extendBlock.velocity = ve;
        down = -0.3f;

        if ((playerPosition - extendBlockPosition) > 2)
        {
            extendBlock.gameObject.SetActive(false);
        } 
    }

    //Make the downward velocity to zero if it is contacted with other objects
    private void OnCollisionStay(Collision other)
    {
        Vector3 hit = other.contacts[0].normal;
        
        float angle = Vector3.Angle(hit, Vector3.up);

        if (Mathf.Approximately(angle, 0))
        {
            //Debug.Log("No Force Now");
            down = 0f;
        }
        
    }
}
