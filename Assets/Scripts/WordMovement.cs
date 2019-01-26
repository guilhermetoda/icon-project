using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordMovement : MonoBehaviour {

    private TextMeshProUGUI _text;

    private void Awake()
    {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Implements the physics of movement
        
        _text.rectTransform.position += new Vector3(200f * Time.deltaTime, 0,0);
    }

    private string spawnWord()
    {
        // Implements the spawning word logic
        return "LOVE";
    }
}
