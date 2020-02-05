using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    bool isEnd = false;

    public float restartDelay = 0.5f;

    public float showIconDelay = 1f;

    public GameObject completeLevelUI;

    public GameObject accelerate;

    public GameObject invincible;

    public Rigidbody player;

    public PlayerColor playerColor;

    public bool is_Invincible = false;

    public float invincibleDelay = 1.5f;

    public FollowPlayer camera;


    private void Start()
    {
        ColorChangeOn();
    }

    public void EndGame()
    {
        if (isEnd == false)
        {
            isEnd = true;
            ColorChangeOff();
            Debug.Log("GameOver!");
            Invoke("Restart", restartDelay);
            
        }
        
    }

    void Restart()
    {
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Won!");
        completeLevelUI.SetActive(true);
    }


    void ColorChangeOff()
    {
        playerColor.ColorChangeOff();
    }

    void ColorChangeOn()
    {
        playerColor.ColorChangeOn();
    }



}
