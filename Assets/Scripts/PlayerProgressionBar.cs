using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerProgressionBar : MonoBehaviour {

    //text component
    private Image _progressionBar;
    
    private void Awake () {
        //get the text component
        _progressionBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log((float)(PlayerProgression.currentLevelProgression / PlayerProgression.LPLevel));
        float progression = (float)PlayerProgression.currentLevelProgression / PlayerProgression.LPLevel;
        transform.localScale = new Vector3(progression, 1, 1);
        //_progressionBar.fillAmount = (float)(PlayerProgression.currentLevelProgression / PlayerProgression.LPLevel);
    }

}
