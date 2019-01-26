﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour {

    //current  score
    public static int currentScore;

    //player's current level
    public static int currentLevel;

    // This variable is here to not make a division at every frame
    public static float currentSpeed;

    //player's current level progression 
    public static int currentLevelProgression;

    //Example: 2-6 
    //Level = 2 / Level Progression = 6
    //Level 2 - 6 words correct

    public static int LPLevel = 10;

    public void Awake()
    {
        currentScore = 0;
        currentLevel = 1;
        currentLevelProgression = 0;
        RecalculateSpeed();
    }

    public static void RecalculateSpeed()
    {
        currentSpeed = (float)currentLevel / 10f;
    }

    public static void NextLP()
    {
        currentLevelProgression += 1;
        if (currentLevelProgression >= LPLevel)
        {
            NextLevel();
        }
    }

    public static void NextLevel()
    {
        currentLevel += 1;
        currentLevelProgression = 0;
        RecalculateSpeed();
    }

    public static void RightWord(int wordScore)
    {
        currentScore += wordScore;
        NextLP();
    }

    public static void PlayerMiss()
    {
        currentLevelProgression = 0;
        // -1000 points for losing the word (CHANGE THAT LATER, DENY!)
        currentScore -= 1000;
    }


}
