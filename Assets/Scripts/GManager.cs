using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    bool isEnd = false;

    public float restartDelay = 2f;

    public float showIconDelay = 1f;

    public float forwardForceSmall = 500f;

    public float forwardForceBig = 10000f;

    public GameObject completeLevelUI;

    public GameObject accelerate;

    public GameObject invincible;

    public Rigidbody player;

    public PlayerColor playerColor;

    public bool is_Invincible = false;

    public float invincibleDelay = 2.5f;

    public void EndGame()
    {
        if (isEnd == false)
        {
            isEnd = true;
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

    public void GetAward()
    {
        Debug.Log("Awarded!");
        ShowSpeedUpIcon();
        AccleratePlayer(forwardForceSmall);
        Invoke("HideSpeedUpIcon", showIconDelay);
        //Debug.Log("Finish Awarding!");


    }

    public void ShowSpeedUpIcon()
    {
        accelerate.SetActive(true);
    }

    public void HideSpeedUpIcon()
    {
        accelerate.SetActive(false);
    }

    public void AccleratePlayer(float forwardForce)
    {
        player.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void GetAward2()
    {
        Debug.Log("Awarded2!");
        InvincibleOn();
        ShowInvincibleIcon();
        AccleratePlayer(forwardForceBig);
        ColorChangeOn();
        Invoke("ShowInvincibleIcon", showIconDelay);
        Invoke("InvincibleOff", invincibleDelay);
        Invoke("ColorChangeOff", invincibleDelay);
    }

    public void InvincibleOn()
    {
        is_Invincible = true;
    }
    
    public void InvincibleOff()
    {
        is_Invincible = false;
    }

    void ColorChangeOff()
    {
        playerColor.ColorChangeOff();
    }

    void ColorChangeOn()
    {
        playerColor.ColorChangeOn();
    }

    public void ShowInvincibleIcon()
    {
        invincible.SetActive(true);
    }

    public void HideInvincibleIcon()
    {
        invincible.SetActive(false);
    }
}
