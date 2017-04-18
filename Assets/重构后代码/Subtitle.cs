using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle : MonoBehaviour {
    public float fadeTime;
    int delayFrames;
    int timer = 0;
    bool isShow;
    Text t;
    Color c;

	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        c = t.color;
        c.a = 0;
        t.color = c;
	}
	
	// Update is called once per frame
	void Update () {
        if (isShow)
        {
            if (timer == 0 && c.a < 1)
            {
                //淡入
                c.a += 1.0f / fadeTime;
                t.color = c;
            }
            else if (timer < delayFrames)
            {
                timer++;
            }
            else if(c.a>0)
            {
                //淡出
                c.a -= 1.0f / fadeTime;
                t.color = c;
            }
            else
            {
                timer = 0;
                isShow = false;
            }
        }
	}

    public void ShowSubtitle(string sub, float delaySeconds)
    {
        t.text = sub;
        delayFrames = (int)(delaySeconds / Time.deltaTime);
        isShow = true;
        timer = 0;
        c.a = 0;
    }
}
