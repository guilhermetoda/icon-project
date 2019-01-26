using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentWord : MonoBehaviour {

    //Spawn Position (-50f, -73f, 0f);
    //End Position (-1024, -73f, 0f);

    [SerializeField] private GameObject[] _wordPrefab; // the word prefab spawn
    private Words wordsObject;
    private static string currentWord;
    private Canvas canvas;
    private static GameObject currentWordObject;

    private Camera cam;


    private void Awake()
    {
        wordsObject = new Words();
        currentWord = "";
        GameObject tempObject = GameObject.Find("ScreenCanvas");
        GameObject tempCamObject = GameObject.Find("MainCamera");

        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            canvas = tempObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        if (tempCamObject != null)
        {
            cam = tempCamObject.GetComponent<Camera>();
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

    private Vector3 GetSpawnPosition()
    {
        float randomY = Random.Range(80, 200);
        Vector3 position = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        position.y += -randomY;
        position.x += 160;

        return position;
    }

    public void SpawnWord()
    {
        // you can't spawn if already exists an object
        int wordType = Random.Range(0, 2);

        if (PlayerProgression.currentLevel > 1)
        {
            wordType = 1; // NEGATIVE WORDS
        }
        else
        {
            wordType = 0; // POSITIVE WORDS
        }

        if (currentWordObject == null) {
            Debug.Log("Creating New word");
            string word = wordsObject.GetRandomWord(wordType);
            currentWord = word;
            Vector3 spawnPosition = GetSpawnPosition();
            Debug.Log(currentWord);
            GameObject newWordObject = _wordPrefab[wordType];
            newWordObject.GetComponent<TextMeshProUGUI>().text = currentWord;
            currentWordObject = Instantiate(newWordObject, spawnPosition, Quaternion.identity);
            currentWordObject.transform.SetParent(canvas.transform, false);
           
        }

    }

    
}
