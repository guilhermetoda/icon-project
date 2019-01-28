using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speechs : MonoBehaviour {

    [SerializeField] private GameObject[] _bubblesPrefab;

    // Use this for initialization
    public void CallSpeech () {
        int index = Random.Range(0, _bubblesPrefab.Length);
        Instantiate(_bubblesPrefab[index], transform.position, transform.rotation);
    }



}
