using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Typing : MonoBehaviour {

    private TextMeshProUGUI _text;

    [SerializeField] private AudioClip audioLevelUp;
    [SerializeField] private AudioClip audioCorrectWord;
    private AudioSource audio;
    
    private void Awake()
    {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
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
                int indexCurrentWord = CheckCurrentWord(_text.text);
                if (indexCurrentWord >= 0)
                {
                    _text.text = "";
                    
                    //Destroy Letter
                    CurrentWord.DestroyWord(indexCurrentWord);
                    if (PlayerProgression.RightWord(100))
                    {
                        // The player just got new level
                        audio.PlayOneShot(audioLevelUp);
                    }
                    else
                    {
                        // The player just got the right word
                        audio.PlayOneShot(audioCorrectWord);
                    }
                   
                   

                }
            }
        }
    }

    private int CheckCurrentWord(string word)
    {
        Debug.Log(CurrentWord.GetCurrentWords()+":"+word);
        List<string> currentWords = CurrentWord.GetCurrentWords();
        for (int i=0; i < currentWords.Count; i++) {
            
            if (word == currentWords[i])
            {
                return i;
            }
        }
        return -1;
    }

}
