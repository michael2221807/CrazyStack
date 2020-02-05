using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ResetGame : MonoBehaviour
{
    public Button startGameButton;

    private GameData gameData;

    private int curLev;

    private int levelPassed;

    private string DATA_PATH = "/GameData.lai";


    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        curLev = 1;
        levelPassed = 0;
        gameData = new GameData(curLev, levelPassed);

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
