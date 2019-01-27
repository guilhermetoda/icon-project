using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentWord : MonoBehaviour {

    [SerializeField] private GameObject[] _wordPrefab; // the word prefab spawn
    private Words wordsObject;
    //private static string[] currentWord;
    private static List<string> currentWords = new List<string>();
    private Canvas canvas;
    private static List<GameObject> currentWordObjects = new List<GameObject>();
    private Camera cam;

    public static CurrentWord invokerController;

    private float _spawnCooldown = 2f;
    private int _maxWordsOnScreen = 4;

    private void Awake()
    {
        invokerController = this;
        wordsObject = new Words();
        //currentWord = "";
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
        invokerController.InvokeRepeating("SpawnWord", 0f, _spawnCooldown);
    }

    // Update is called once per frame
    /*void Update () {



		if (currentWord == "")
        {
            SpawnWord();
        }
	}*/

    public static void ResetWords()
    {
        //Stop Invoke to Reinvoke
        invokerController.CancelInvoke();
        DestroyAllWordObjects();
    }

    public static void InvokeSpawn(float cooldown)
    {
        invokerController.InvokeRepeating("SpawnWord", 0f, cooldown);
    }

    //This will destroy every word object that still are in the scene
    public static void DestroyAllWordObjects()
    {
        for (int i=0; i < currentWordObjects.Count; i++)
        {
            DestroyWord(i);
        }
    }

    public void SetCurrentWord(string word)
    {
        currentWords.Add(word);
    }

    public static List<string> GetCurrentWords()
    {
        return currentWords;
    }

    public static List<GameObject> GetCurrentWordObjects()
    {
        return currentWordObjects;
    }

    public static void DestroyWord(int index)
    {
        Destroy(currentWordObjects[index].gameObject);
        currentWordObjects.RemoveAt(index);
        currentWords.RemoveAt(index);
    }

    public static void DestroyWordByText(string text)
    {
        int index = CheckCurrentWord(text);
        if (index >= 0)
        {
            DestroyWord(index);
        }
                       
    }

    private static int CheckCurrentWord(string word)
    {
        List<string> currentWords = GetCurrentWords();
        for (int i = 0; i < currentWords.Count; i++)
        {
            if (word == currentWords[i])
            {
                return i;
            }
        }
        return -1;
    }

    private Vector3 GetSpawnPosition()
    {
        float randomY = Random.Range(80, 200);
        Vector3 position = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        position.y += -randomY;
        position.x += 200;

        return position;
    }

    public void SpawnWord()
    {

        if (currentWords.Count <= _maxWordsOnScreen)
        {

            // you can't spawn if already exists an object
            int wordType = Random.Range(0, 2);

            if (PlayerProgression.currentLevel % 2 == 1)
            {
                wordType = 1; // NEGATIVE WORDS
            }
            else
            {
                wordType = 0; // POSITIVE WORDS
            }


            string word = wordsObject.GetRandomWord(wordType);
            SetCurrentWord(word);
            Vector3 spawnPosition = GetSpawnPosition();

            GameObject newWordObject = _wordPrefab[wordType];

            //newWordObject.GetComponent<TextMeshProUGUI>().text = word; // use wordMovement2 instead of original. call spawnWord method from here
            newWordObject.GetComponent<WordMovement>().spawnWord(word);
            GameObject currentWordObject = Instantiate(newWordObject, spawnPosition, Quaternion.identity);
            currentWordObject.transform.SetParent(canvas.transform, false);
            currentWordObjects.Add(currentWordObject);
        }
    }

    
}
