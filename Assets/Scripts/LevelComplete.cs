using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LevelComplete : MonoBehaviour
{

    private GameData gameData;

    private int levelPassed;

    private string DATA_PATH = "/GameData.lai";
    public void LoadNextLevel()
    {
        LoadData();

        if (gameData != null)
        {
            levelPassed = gameData.LevelPassed;
        }else
        {
            gameData = new GameData(1, 0);
        }


        int curLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = UnityEngine.Random.Range(1, 4);

        while (nextLevel == curLevel)
        {
            nextLevel = UnityEngine.Random.Range(1, 4);
        }
        
        SceneManager.LoadScene(nextLevel);

        gameData = new GameData(nextLevel, levelPassed + 1);

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
