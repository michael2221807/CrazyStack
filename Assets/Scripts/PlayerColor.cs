using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject player;

    public bool is_ColorChange = false;

    public Color defaultColor;

    private void Start()
    {
        defaultColor = player.GetComponent<MeshRenderer>().material.color;
    }

    void FixedUpdate()
    {
        if (is_ColorChange)
        {
            Debug.Log("Color is changing!");
            player.GetComponent<MeshRenderer>().material.color = Color.Lerp(defaultColor, Color.red, Mathf.PingPong(Time.time * 2.5f, 1));

        }
        else if (!is_ColorChange)
        {
            player.GetComponent<MeshRenderer>().material.color = defaultColor;
        }
    }

    public void ColorChangeOff()
    {
        is_ColorChange = false;
    }

    public void ColorChangeOn()
    {
        is_ColorChange = true;
    }
}
