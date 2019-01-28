using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    [SerializeField] private GameObject camOffice;
    [SerializeField] private GameObject camHome;
    [SerializeField] private GameObject mainCam;

    [SerializeField] private AudioClip HomeMusic;
    [SerializeField] private AudioClip OfficeMusic;

    [SerializeField] private float _shakeDistance = 0.01f;
    [SerializeField] private float _shakeSpeed = 2f;
    private float _currentPosition = 0;

    private Vector3 cameraPosition;
    private AudioSource audio;

    // Update is called once per frame
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        ChangeToOfficeCamera();
    }

    private void Update()
    {
        _currentPosition += Time.deltaTime * _shakeSpeed;
        if (_currentPosition >= 360)
        {
            _currentPosition -= 360;
        }

        transform.localPosition = cameraPosition + new Vector3(Mathf.Sin(_currentPosition * 2.17f), Mathf.Cos(_currentPosition), Mathf.Cos(_currentPosition * 1.23f)) * _shakeDistance;
    }

    /*private void ChangeCameraPosition(Vector3 cam1Position, Quaternion cam1Rotation, Vector3 cam2Position, Quaternion cam2Rotation)
    { 
        cam1Position = cam2Position;
        cam1Rotation = cam2Rotation;
    }*/
    public void ChangeToHomeCamera()
    {
        mainCam.transform.localPosition = camHome.transform.localPosition;
        mainCam.transform.localRotation = camHome.transform.localRotation;
        cameraPosition = camHome.transform.localPosition;
        GameObject.Find("ScreenCanvas").GetComponent<Canvas>().worldCamera = mainCam.GetComponent<Camera>();
        audio.Stop();
        audio.loop = true;
        audio.PlayOneShot(HomeMusic); 
    }
    public void ChangeToOfficeCamera()
    {
        mainCam.transform.localPosition = camOffice.transform.localPosition;
        mainCam.transform.localRotation = camOffice.transform.localRotation;
        cameraPosition = camOffice.transform.localPosition;
        GameObject.Find("ScreenCanvas").GetComponent<Canvas>().worldCamera = mainCam.GetComponent<Camera>();
        audio.Stop();
        audio.loop = true;
        audio.PlayOneShot(OfficeMusic);
        
    }

    

}