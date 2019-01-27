using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckEnter : MonoBehaviour {

    //public static Typing TextBox;
    private TextMeshProUGUI _text;

    //[SerializeField] private AudioClip audioLevelUp;
    [SerializeField] private AudioClip audioCorrectWord;
    [SerializeField] private float delayBeforeLoading = 0.5f;
    private AudioSource audio;

    private float timeElapsed;
    private bool activate = false;
    private string _input = "";

    private void Awake()
    {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
        //TextBox = this;
    }

    private void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (_text.text.Length != 0)
                {
                    _text.text = _text.text.Substring(0, _text.text.Length - 1);
                }
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
                    // The player just got the right word
                    audio.PlayOneShot(audioCorrectWord);
                    //Fadethetext.ActivateFade();
                    Fading.BeginFade(1);
                    activate = true;
                }
            }
        }

        if (activate)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene("Home");
        }
    }
    private void BackSpace()
    {
       
    }

    private void AddInputCharacter(char input)
    {
        _text.text += input;
    }

    public void ClearInputText()
    {
        _input = "";
        _text.text = _input;
    }

    private int CheckCurrentWord(string word)
    {
        string enter = "enter";
        if (word == enter)
        {
            return 1;
        }
        return -1;
    }
}
