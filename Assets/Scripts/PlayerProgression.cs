using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour 
{


    private static AudioSource audio;

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
        audio = GetComponent<AudioSource>();
    }

    public static void RecalculateSpeed()
    {
        currentSpeed = (float)currentLevel / 10f;
    }

    public static bool NextLP()
    {
        currentLevelProgression += 1;
        if (currentLevelProgression >= LPLevel)
        {
            NextLevel();
            return true;
        }
        return false;
    }

    public static void NextLevel()
    {
        currentLevel += 1;
        currentLevelProgression = 0;
        RecalculateSpeed();
        if (currentLevel % 2 == 1 )
        {
            GameObject.Find("MainCamera").GetComponent<CameraTransition>().ChangeToOfficeCamera();
        }
        else
        {
            GameObject.Find("MainCamera").GetComponent<CameraTransition>().ChangeToHomeCamera();
        }
    }

    //Returns true if the player reaches new level
    public static bool RightWord(int wordScore)
    {
        currentScore += wordScore;
        return NextLP();
    }

    public static void PlayerMiss()
    {
        currentLevelProgression = 0;
        audio.Play();
        // -1000 points for losing the word (CHANGE THAT LATER, DENY!)
        currentScore -= 1000;
    }


}
