using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public static float fadeSpeed = 1f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;//entre 0 e 1
    private static int fadeDirection = -1; //fade in=-1,fade out=+1

	void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
	public static float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }
    void OnLevelWasLoaded()
    {
        //alpha=-1; 
        BeginFade(-1);
    }

}
