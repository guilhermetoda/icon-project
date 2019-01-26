using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour {

    private string[] positiveWords;
    private string[] negativeWords;

	public Words()
    {
        string[] wordsList = new string[2];
        wordsList[0] = "love";
        wordsList[1] = "family";
        positiveWords = wordsList;

        string[] wordsList2 = new string[2];
        wordsList2[0] = "stress";
        wordsList2[1] = "deadline";
        negativeWords = wordsList2;
    }

    // wordType
    // 0 - Positive
    // 1 - Negative
    public string GetRandomWord(int wordType)
    {
        if (wordType == 0)
        {
            Debug.Log("POSITIVE WORD"+positiveWords[0]);
            return GetRandomWordFromArray(positiveWords);
        }
        else
        {
            Debug.Log("NEGATIVE WORD");
            return GetRandomWordFromArray(negativeWords);
        }
    }

    public string GetRandomWordFromArray(string[] wordsList)
    {
        //get the text component
        int randomNumber = Random.Range(0, wordsList.Length);
        return wordsList[randomNumber];
    }
}
