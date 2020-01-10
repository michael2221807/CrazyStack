using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;

    public float sidewayForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(0, 0, 2000 * Time.deltaTime);
    }

    //Update that works with physics better.
    void FixedUpdate()
    {
        //Debug.Log(rb.velocity);

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y <= -1f)
        {
            FindObjectOfType<GManager>().EndGame();

        }
    }


}
