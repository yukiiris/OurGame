using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogFade : MonoBehaviour
{
    private float fadeTime = 100f;//@@@@@可修改
    private bool ifFade = false;//@@@@@可修改

    public bool isFadeIn;
    private Image rend;
    private Text trend;
    private Color col;
    private Color tcol;

    void Start()
    {
        rend = GetComponent<Image>();
        trend = GetComponentInChildren<Text>();
        col = rend.color;
        tcol = trend.color;
        if (isFadeIn)
        {
            col.a = 0;
            tcol.a = 0;
            rend.color = col;
            trend.color = tcol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ifFade == true)
        {
            if (isFadeIn)
            {
                rend.color = col;
                trend.color = tcol;
                col.a +=  1 / fadeTime;
                tcol.a += 1 / fadeTime;
                if (col.a >= 1)
                {
                    ifFade = false;
                }
            }
            else
            {
                rend.color = col;
                trend.color = tcol;
                col.a -=  1 / fadeTime;
                tcol.a -= 1 / fadeTime;
                if (col.a <= 0)
                {
                    ifFade = false;
                }
            }

        }
    }

    public void FadeIn(float delayTime = 0.2f)
    {
        col.a = 0;
        tcol.a = 0;
        rend.color = col;
        trend.color = tcol;

        fadeTime = delayTime * 60;
        ifFade = true;
        isFadeIn = true;
    }
    public void FadeOut(float delayTime = 0.2f)
    {

        fadeTime = delayTime * 60;
        ifFade = true;
        isFadeIn = false;
    }
}

