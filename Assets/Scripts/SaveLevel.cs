using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class GameData
{
    private int _curLevel;
    private int _levelPassed;
    private int _highestScore;
    private bool _notDie;
    private int _prevHighest;

    private GameData() { }

    public GameData(int curLevel, int levelPassed, int highestScore, bool notDie, int prevHighest)
    {
        _curLevel = curLevel;
        _levelPassed = levelPassed;
        _highestScore = highestScore;
        _notDie = notDie;
        _prevHighest = prevHighest;
    }
    public int PreHighest
    {
        get
        {
            return _prevHighest;
        }
    } 
        
    public bool NotDie
    {
        get
        {
            return _notDie;
        }
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

    public int HighestScore
    {
        get
        {
            return _highestScore;
        }
    }
}
    

