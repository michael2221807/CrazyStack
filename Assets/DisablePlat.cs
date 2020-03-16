using UnityEngine;

public class DisablePlat : MonoBehaviour
{
    public Rigidbody player;
    public GameObject platform;

    void FixedUpdate()
    {
        if (player.transform.position.z - platform.transform.position.z > 100 && Mathf.Abs(player.transform.position.y - platform.transform.position.y) < 10 )
        {
            platform.SetActive(false);
        }
    }
}
