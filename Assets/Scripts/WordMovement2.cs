using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordMovement2 : MonoBehaviour
{

    private TextMeshProUGUI _textUnder;
    private TextMeshProUGUI _textOver;
    private Camera cam;

    private void Awake()
    {
        //get the text component
        _textUnder = transform.Find("Under").GetComponent<TextMeshProUGUI>();
        _textOver = transform.Find("Over").GetComponent<TextMeshProUGUI>();
        GameObject tempObject = GameObject.Find("MainCamera");
        cam = tempObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Implements the physics of movement

        bool isFullyVisible = _textUnder.GetComponent<RectTransform>().IsFullyVisibleFrom(cam);
        if (isFullyVisible)
        {
            // This is a UI element since it has a RectTransform component on it
            _textUnder.rectTransform.position += new Vector3(PlayerProgression.currentSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            Debug.Log("IS NOT FULLY VIS");

            CurrentWord.DestroyWord();
            PlayerProgression.PlayerMiss();
        }

    }

    public void spawnWord(string word)
    {
        _textUnder.text = word;
        _textOver.text = "";
    }
}
