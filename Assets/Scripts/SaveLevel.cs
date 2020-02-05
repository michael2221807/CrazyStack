using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class GameData
{
    private int _curLevel;
    private int _levelPassed;

    private GameData() { }

    public GameData(int curLevel, int levelPassed)
    {
        _curLevel = curLevel;
        _levelPassed = levelPassed;
    }
        

    public int CurLevel
    {
        get
        {
            return _curLevel;
        }
        
    }


    public int LevelPassed
    {
        get
        {
            return _levelPassed;
        }
  
    }
}
    

