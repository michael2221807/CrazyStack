using UnityEngine;

public class DisablePlat : MonoBehaviour
{
    public Rigidbody player;
    public GameObject platform;

    void FixedUpdate()
    {
        if (player.transform.position.z - platform.transform.position.z > 120 && Mathf.Abs(player.transform.position.y - platform.transform.position.y) < 10 )
        {
            //Debug.Log(platform, player);
            //platform.SetActive(false);
            Destroy(platform);
        }
    }
}
