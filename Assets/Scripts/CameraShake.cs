using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool fasterShake;

    [SerializeField] private float _shakeDistance = 0.011f;
    [SerializeField] private float _shakeSpeed = 1f;

    private float _currentPosition = 0;
    private Vector3 _startLocation;

    // Use this for initialization
    void Awake()
    {
        _startLocation = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _currentPosition += Time.deltaTime * _shakeSpeed;
        if (_currentPosition >= 360)
        {
            _currentPosition -= 360;
        }

        transform.localPosition = _startLocation + new Vector3(Mathf.Sin(_currentPosition), Mathf.Cos(_currentPosition * 1.47f), Mathf.Cos(_currentPosition * 1.23f)) * _shakeDistance;
    }
}