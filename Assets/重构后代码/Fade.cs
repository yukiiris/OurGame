using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
    private float fadeTime = 100f;//@@@@@可修改
    private bool ifFade = false;//@@@@@可修改
    bool isFadeIn = true;
    bool isDisappearing = false;
    bool isDisappearingD = false;
    private Renderer rend;
    private Color col;
    private Material begin;


    void Awake()
    {
        rend = GetComponent<Renderer>();
        col = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifFade == true)
        {
            if (isFadeIn)
            {
                rend.material.color = col;
                col.a = col.a + 1 / fadeTime;
                if (col.a >= 1)
                {
                    col.a = 1;
                    rend.material.color = col;
                    ifFade = false;
					if (isDisappearingD)
						Destroy (this);
                }
            }
            else
            {
                rend.material.color = col;
                col.a = col.a - 1 / fadeTime;
                if (col.a <= 0)
                {
                    col.a = 0;
                    rend.material.color = col;
                    ifFade = false;
                    if (isDisappearing) Destroy(gameObject);
					Destroy (this);
                }
            }

        }
    }

	public void FadeIn(float delayTime = 0.2f,bool isD=true)
    {
		col.a = 0;
		rend.material.color = col;
        fadeTime = delayTime/Time.deltaTime;
        ifFade = true;
        isFadeIn = true;
		isDisappearingD = isD;
    }
    public void hide()
    {
        col.a = 0;
        rend.material.color = col;
		Destroy (this);
    }
    public void FadeOut(float delayTime = 0.2f)
    {
        fadeTime = delayTime / Time.deltaTime;
        ifFade = true;
        isFadeIn = false;
        col.a = 1;
        rend.material.color = col;
    }
    public void Disappear(float delayTime = 0.2f)
    {
        fadeTime = delayTime / Time.deltaTime;
        ifFade = true;
        isFadeIn = false;
        isDisappearing = true;
        col.a = 1;
        rend.material.color = col;
    }
	public static void Hide(GameObject g){
		g.AddComponent<Fade> ();
		g.GetComponent<Fade> ().hide ();
	}
	public static void FadeIn(GameObject g, float delayTime = 0.2f)
	{
		g.AddComponent<Fade> ();
		g.GetComponent<Fade> ().FadeIn (delayTime);
	}
	public static void FadeOut(GameObject g, float delayTime = 0.2f)
	{
		g.AddComponent<Fade> ();
		g.GetComponent<Fade> ().FadeOut (delayTime);
	}
	public static void Disappear(GameObject g, float delayTime = 0.2f)
	{
		g.AddComponent<Fade> ();
		g.GetComponent<Fade> ().Disappear (delayTime);
	}
}
