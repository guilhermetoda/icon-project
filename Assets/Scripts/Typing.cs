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

    private string _input = "";
    
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
                BackSpace();
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                ClearInputText();
            }
            // TO DO: We can't allow spacebar
            else
            {
                char lowerChar = char.ToLower(c);
                AddInputCharacter(lowerChar);
                int indexCurrentWord = CheckCurrentWord(_text.text);
                if (indexCurrentWord >= 0)
                {
                    ClearInputText();
                    
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

    private void BackSpace()
    {
        if (_text.text.Length != 0)
        {
            _text.text = _text.text.Substring(0, _text.text.Length - 1);
        }
    }

    private void AddInputCharacter(char input)
    {
        print("DSDSDD: " + input);
        _input += input;
        _text.text = _input;
        if (!HighlightWords(_input))
        {
            ClearInputText();
        }
    }

    private void ClearInputText()
    {
        _input = "";
        _text.text = _input;
        HighlightWords(_input);
    }

    private bool HighlightWords(string input)
    {
        List<string> currentWords = CurrentWord.GetCurrentWords();
        List<GameObject> currentObjects = CurrentWord.GetCurrentWordObjects();
        bool wordFound = false;

        if (currentWords.Count != currentObjects.Count)
        {
            throw new System.Exception("word and object list does not match wtf");
        }

        for (int i = 0; i < currentObjects.Count; i++)
        {
            string checkmatch = currentWords[i].Substring(0, input.Length);
            print(input + "::: " + input);
            if (input.Equals(checkmatch))
            {
                currentObjects[i].GetComponent<WordMovement>().updateHighlighting(input);
                wordFound = true;
            }
        }

        return wordFound;
    }

    private int CheckCurrentWord(string word)
    {
        //Debug.Log(CurrentWord.GetCurrentWords()+":"+word);
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
