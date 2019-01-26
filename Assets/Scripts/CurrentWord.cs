using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentWord : MonoBehaviour {

    private static string currentWord;
    private Canvas canvas;
    [SerializeField] private GameObject _wordPrefab; // the word prefab spawn
    private static string[] _wordsList;
    private static GameObject currentWordObject;

    private void Awake()
    {
        currentWord = "";
        GameObject tempObject = GameObject.Find("ScreenCanvas");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            canvas = tempObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
        SpawnWord();
      
    }

    // Update is called once per frame
    void Update () {
		if (currentWord == "")
        {
            SpawnWord();
        }
	}

    public void SetCurrentWord(string word)
    {
        currentWord = word;
    }

    public static string GetCurrentWord()
    {
        return currentWord;
    }

    public static void DestroyWord()
    {
        Debug.Log("Destroying Word");
        
        Destroy(currentWordObject.gameObject);
       
        currentWord = "";
    }

    private static string GetRandomWord()
    {
        //get the text component
        _wordsList = new string[2];
        _wordsList[0] = "LOVE";
        _wordsList[1] = "FAMILY";

        int randomNumber = Random.Range(0, _wordsList.Length);
        return _wordsList[randomNumber];
    }

    public void SpawnWord()
    {
        // you can't spawn if already exists an object

        if (currentWordObject == null) {
            Debug.Log("Creating New word");
            string word = GetRandomWord();
            currentWord = word;
            Vector3 spawnPosition = new Vector3(150f, -73f, 0f);
            Debug.Log(currentWord);
            GameObject newWordObject = _wordPrefab;
            newWordObject.GetComponent<TextMeshProUGUI>().text = currentWord;
            currentWordObject = Instantiate(newWordObject, spawnPosition, Quaternion.identity);
            currentWordObject.transform.SetParent(canvas.transform, false);
            Debug.Log("AAA"+currentWordObject.GetComponent<TextMeshProUGUI>().text);
           
        }

    }

    
}
