using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressColor : MonoBehaviour {

    private float _position = 0;
    private readonly float _speed = 8;
    private RawImage _image;
	// Use this for initialization
	void Awake () {
        _image = GetComponent<RawImage>();
    }
	
	// Update is called once per frame
	void Update () {
        _position += Time.deltaTime * _speed;
        if (_position >= 360)
            _position -= 360;

        _image.color = Color.HSVToRGB(Mathf.Sin(_position) * 0.015f + 0.62f, 1, 1);
	}
}
