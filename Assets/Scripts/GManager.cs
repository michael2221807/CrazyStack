using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

    private int curLev;

    private int levelPassed;

    private int highestScore;

    private bool notDie;

    private int prevHighest;

    private string DATA_PATH = "/GameData.lai";

    private GameData gameData;


    private void Start()
    {
        ColorChangeOn();

        LoadData();
        if (gameData != null)
        {
            curLev = gameData.CurLevel;
            levelPassed = gameData.LevelPassed;
            highestScore = gameData.HighestScore;
            notDie = gameData.NotDie;
            prevHighest = gameData.PreHighest;
        }
        else
        {
            curLev = 1;
            levelPassed = 0;
            highestScore = 0;
            notDie = true;
            prevHighest = 0;
            gameData = new GameData(curLev, levelPassed, highestScore, notDie, prevHighest);
        }
    }

    public void EndGame()
    {
        if (isEnd == false)
        {
            isEnd = true;
            ColorChangeOff();
            Debug.Log("GameOver!");
            Invoke("Restart", restartDelay);
            if (notDie)
            {
                
                int playerDistance = Convert.ToInt32(player.transform.position.z + 2355);
                if (highestScore < prevHighest + playerDistance)
                {
                    highestScore = prevHighest + playerDistance;
                    prevHighest = 0;

                }
                else if (highestScore == 0)
                {
                    highestScore = playerDistance;
                    prevHighest = 0;

                }
                gameData = new GameData(curLev, levelPassed, highestScore, notDie, prevHighest);
                SaveData();
            }
            
            
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

    void SaveData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DATA_PATH);

            bf.Serialize(file, gameData);



        }
        catch (Exception e)
        {
            if (e != null)
            {
                Debug.LogError("Save Fail!");
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }

    }

    void LoadData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + DATA_PATH, FileMode.Open);

            gameData = bf.Deserialize(file) as GameData;



        }
        catch (Exception e)
        {
            if (e != null)
            {
                Debug.LogError("Load Fail!");
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }



}
