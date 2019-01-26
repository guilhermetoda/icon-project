using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] public float spinSpeed = 50f;
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
