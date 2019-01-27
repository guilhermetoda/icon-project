using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordMovement : MonoBehaviour {

    
    [SerializeField] private TextMeshProUGUI _textUnder;
    [SerializeField] private TextMeshProUGUI _textOver;

    private Camera cam;


    private void Awake()
    {
        //get the text component
        //_textUnder = GetComponent<TextMeshProUGUI>();
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
            UpdatePosition(Time.deltaTime);
        }
        else
        {
            CurrentWord.DestroyWordByText(_textUnder.text);
            PlayerProgression.PlayerMiss();
        }

    }

    private void UpdatePosition(float time)
    {
        if (PlayerProgression.currentLevel % 2 == 1)
        {
            _textUnder.rectTransform.position -= new Vector3(PlayerProgression.currentSpeed * time, 0, 0);
            _textOver.rectTransform.position = _textUnder.rectTransform.position;
        }
        else
        {
            _textUnder.rectTransform.position += new Vector3(PlayerProgression.currentSpeed * time, 0, 0);
            _textOver.rectTransform.position = _textUnder.rectTransform.position;
        }
    }

    public void Mistake()
    {
        UpdatePosition(0.1f);
    }

    public void spawnWord(string word)
    {
        _textUnder.text = word;
        _textOver.text = "";
    }

    public void updateHighlighting(string input)
    {
        _textOver.text = input;
    }

    public void clearHighlighting()
    {
        _textOver.text = "";
    }
}
