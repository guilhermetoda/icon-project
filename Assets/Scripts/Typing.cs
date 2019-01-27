using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Typing : MonoBehaviour {

    private TextMeshProUGUI _text;

    private void Awake()
    {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                // TO DO: Improve the feedback of backspace

                if (_text.text.Length != 0)
                {
                    _text.text = _text.text.Substring(0, _text.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                _text.text = "";
            }
            // TO DO: We can't allow spacebar
            else
            {

                char lowerChar = char.ToLower(c);
                _text.text += lowerChar;
                if (CheckCurrentWord(_text.text))
                {
                    _text.text = "";
                    CurrentWord.PlayCorrectSound();  // plays sound when collided.
                    //Destroy Letter
                    CurrentWord.DestroyWord();

                    //User get Points
                    PlayerProgression.RightWord(100);

                }
            }
        }
    }

    private bool CheckCurrentWord(string word)
    {
        Debug.Log(CurrentWord.GetCurrentWord()+":"+word);
        return word == CurrentWord.GetCurrentWord();
    }

}
