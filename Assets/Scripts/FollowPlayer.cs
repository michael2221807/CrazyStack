using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 defaultOffset = new Vector3(0, 1, -5);
    public bool is_Zoom = false;
    public float maxDistance;
    public float deltaT;
    public bool reset = false;
    public float t = 0.0f;


    // Update is called once per frame
    void Update()
    {
        if (!is_Zoom && !reset)
        {
            Vector3 zOnly = player.position;
            zOnly.y = 0;

            transform.position = zOnly + offset;
        }
        else if (is_Zoom)
        {
            offset = offset + new Vector3(0, 0, Mathf.Lerp(0, maxDistance, t));
            transform.position = player.position + offset;
            t += deltaT * Time.deltaTime;

            if (t > 0.15f)
            {
                t = 0f;
                is_Zoom = false;
            }
        }
        else if (reset)
        {
            offset = offset - new Vector3(0, 0, Mathf.Lerp(0, maxDistance, t));
            transform.position = player.position + offset;
            t += deltaT * Time.deltaTime;

            if (t > 0.15f)
            {
                //offset = defaultOffset;
                t = 0f;
                reset = false;
            }
        }
        
    }

    public void Zoom(float max, float deltaTime)
    {
        maxDistance = max;
        deltaT = deltaTime;
        is_Zoom = true;
    }


    public void ResetOffset()
    {
        is_Zoom = false;
        reset = true;
    }
}
