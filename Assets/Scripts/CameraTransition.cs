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
    private AudioSource audio;


    // Update is called once per frame
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
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
        GameObject.Find("ScreenCanvas").GetComponent<Canvas>().worldCamera = mainCam.GetComponent<Camera>();
        audio.Stop();
        audio.PlayOneShot(HomeMusic); 
    }
    public void ChangeToOfficeCamera()
    {
        mainCam.transform.localPosition = camOffice.transform.localPosition;
        mainCam.transform.localRotation = camOffice.transform.localRotation;
        GameObject.Find("ScreenCanvas").GetComponent<Canvas>().worldCamera = mainCam.GetComponent<Camera>();
        audio.Stop();
        audio.PlayOneShot(OfficeMusic);
    }

    

}