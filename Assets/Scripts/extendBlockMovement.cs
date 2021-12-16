using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extendBlockMovement : MonoBehaviour
{
    public Rigidbody player;
    public Rigidbody extendBlock;
    public Transform frontHitDetector;
    public LayerMask obsMask;
    bool hitFront;

    public float radius = 0.1f;

    public float v = 25f;

    public float down = -0.3f;

    public bool lockZ = true;


    // Start is called before the first frame update
    void Start()
    {
        extendBlock.velocity = player.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hitFront = Physics.CheckSphere(frontHitDetector.position, radius, obsMask);
        float playerPosition = player.transform.position.z;
        float extendBlockPosition = extendBlock.transform.position.z;
        //extendBlock.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);

        Vector3 playerPos = player.transform.position;
        Vector3 extendPos = extendBlock.transform.position;
        if (lockZ)
        {
            Vector3 newPos = new Vector3(playerPos.x, extendPos.y, playerPos.z);
            extendBlock.transform.position = newPos;
        }
        else
        {
            Vector3 newPos = new Vector3(playerPos.x, extendPos.y, extendPos.z);
            extendBlock.transform.position = newPos;
        }
        


        Vector3 ve = player.velocity.normalized;
        ve.x = 0f;
        ve.y = down;
        ve *= v;
        extendBlock.velocity = ve;
        down = -0.3f;

        if ((playerPosition - extendBlockPosition) > 1)
        {
            //extendBlock.gameObject.SetActive(false);
            Destroy(extendBlock.gameObject);
        } 
    }

    //Make the downward velocity to zero if it is contacted with other objects
    private void OnCollisionStay(Collision other)
    {
        Vector3 hit = other.contacts[0].normal;

        float angle = Vector3.Angle(hit, Vector3.up);

        float angle1 = Vector3.Angle(hit, Vector3.forward);

        if (Mathf.Approximately(angle, 0))
        {
            //Debug.Log("no force now");
            down = 0f;
        }

        if (hitFront)
        {
            lockZ = false;
            //Debug.Log("hit front?");

        }
        
    }
}
