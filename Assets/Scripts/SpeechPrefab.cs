using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechPrefab : MonoBehaviour {

    [SerializeField] private float _lifeTime = 3f; // life time until destruction

    // Use this for initialization
    private void Awake () {
        //destroy after life time ends
        Destroy(gameObject, _lifeTime);
    }
	
}
