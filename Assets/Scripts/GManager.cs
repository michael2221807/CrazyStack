using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    bool isEnd = false;

    public float restartDelay = 2f;

    public float showSpeedUpIconDelay = 1f;

    public float forwardForce = 500f;

    public GameObject completeLevelUI;

    public GameObject accelerate;

    public GameObject awardBlock;

    public Rigidbody player;

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
        AccleratePlayer();
        Invoke("HideSpeedUpIcon", showSpeedUpIconDelay);
        Debug.Log("Finish Awarding!");


    }

    public void ShowSpeedUpIcon()
    {
        accelerate.SetActive(true);
    }

    public void HideSpeedUpIcon()
    {
        accelerate.SetActive(false);
    }

    public void AccleratePlayer()
    {
        player.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void GetAward2()
    {
        Debug.Log("Awarded2!");
        
    }

    
}
