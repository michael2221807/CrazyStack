using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LevelComplete : MonoBehaviour
{

    private GameData gameData;

    private int levelPassed;

    private int highestScore;

    private bool notDie;

    private int prevHighest;

    private string DATA_PATH = "/GameData.lai";

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void LoadNextLevel()
    {
        LoadData();

        if (gameData != null)
        {
            levelPassed = gameData.LevelPassed;

            highestScore = gameData.HighestScore;

            notDie = gameData.NotDie;

            prevHighest = gameData.PreHighest;
        }
        else
        {
            gameData = new GameData(1, 0, 0, true, 0);
        }


        int curLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = UnityEngine.Random.Range(1, 5);

        while (nextLevel == curLevel)
        {
            nextLevel = UnityEngine.Random.Range(1, 5);
        }
        
        SceneManager.LoadScene(nextLevel);

        notDie = true;

        int playerDistance = Convert.ToInt32(player.transform.position.z + 2355);

        if (highestScore < prevHighest + playerDistance)
        {
            highestScore = prevHighest + playerDistance;
            prevHighest = highestScore;
        }
        else if (highestScore == 0)
        {
            highestScore = playerDistance;
            prevHighest = 0;
        }

        gameData = new GameData(nextLevel, levelPassed + 1, highestScore, notDie, prevHighest);

        SaveData();
    }

    void SaveData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DATA_PATH);

            bf.Serialize(file, gameData);



        } catch (Exception e)
        {
            if (e != null)
            {
                Debug.LogError("Save Fail level complete!");
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
