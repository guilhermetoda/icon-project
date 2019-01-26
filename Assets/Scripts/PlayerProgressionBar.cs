using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgressionBar : MonoBehaviour {

    //text component
    private TextMeshProUGUI _text;


    private void Awake () {
        //get the text component
        _text = GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        _text.SetText("Level " + PlayerProgression.currentLevel +" | "+PlayerProgression.currentLevelProgression.ToString()+"/"+PlayerProgression.LPLevel);
    }
}
