using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float upwardForce = 20f;

    public bool isJump = false;

    public Rigidbody extendBlock;

    public float v = 25f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
        //isGrounded = true;
        rb.velocity = new Vector3(0f, 0f, 100f);

    }

    // Update is called once per frame

    void FixedUpdate()
    {

        Vector3 ve = rb.velocity.normalized;
        ve *= v;
        rb.velocity = ve;

        //Debug.Log(rb.velocity);

   

        if (rb.position.y <= -1f)
        {
            FindObjectOfType<GManager>().EndGame();

        }

        if (Input.GetKey("space"))
        {
            jump();
        }


    }
    private void jump()
    {
        if (!isJump)
        {
            isJump = true;
            Debug.Log("Jump!");

            rb.AddForce(new Vector3(0f, 1f, 0f) * upwardForce, ForceMode.VelocityChange);
            Invoke("SpawnBlock", 0.10f);
            Invoke("resetIsJumping", 0.3f);


        }
    }

    private void resetIsJumping()
    {
        isJump = false;
    }

    private void SpawnBlock()
    {
        Vector3 offset = new Vector3(0, -1.2f, 0f);
        Instantiate(extendBlock, rb.position + offset, rb.rotation);
    }


}
