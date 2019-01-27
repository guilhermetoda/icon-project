using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fadethetext : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float delayBeforeLoading = 1.5f;
    private float timeElapsed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            _anim.SetBool("activateFade", true);
        }
        if (_anim.GetBool("activateFade"))
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene("Home");
        }
    }
}
