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
                //
            }
            // TO DO: We can't allow spacebar
            else
            {
                _text.text += c;
                if (CheckCurrentWord(_text.text))
                {
                    _text.text = "";
                    //Destroy Letter
                    Debug.Log("DestroyLETTER");
                    CurrentWord.DestroyWord();
                    //Spawn another letter
                    // Update of CurrentWords
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
