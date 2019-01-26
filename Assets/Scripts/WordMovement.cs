using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordMovement : MonoBehaviour {

    private TextMeshProUGUI _text;
    private Camera cam;

    private void Awake()
    {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
        GameObject tempObject = GameObject.Find("MainCamera");
        cam = tempObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Implements the physics of movement
        
        bool isFullyVisible = _text.GetComponent<RectTransform>().IsFullyVisibleFrom(cam);
        if (isFullyVisible)
        {
            // This is a UI element since it has a RectTransform component on it
            _text.rectTransform.position += new Vector3(PlayerProgression.currentSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            Debug.Log("IS NOT FULLY VIS");
            
            CurrentWord.DestroyWord();
            PlayerProgression.PlayerMiss();
        }

    }

    private string spawnWord()
    {
        // Implements the spawning word logic
        return "LOVE";
    }
}
