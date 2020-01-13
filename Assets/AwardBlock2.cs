﻿using UnityEngine;

public class AwardBlock2 : MonoBehaviour
{
    public GameObject awardBlock;

    public GManager gameManager;

    public float height;

    public Vector3 rotation;

    public void Start()
    {
        awardBlock.GetComponent<Rigidbody>().useGravity = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Wall")
        {
            gameManager.GetAward2();
            
        }
    }

    private void floating()
    {
        if (awardBlock.transform.position.y > height)
        {
            awardBlock.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f);
            
        }
        if (awardBlock.transform.position.y <= height)
        {
            awardBlock.GetComponent<Rigidbody>().AddForce(Vector3.up * 98f);

        }
    }

    private void enlarge()
    {

    }

    private void Spin()
    {
        awardBlock.transform.Rotate(rotation, Space.Self);
    }

    public void FixedUpdate()
    {
        floating();
        Spin();
    }
}
