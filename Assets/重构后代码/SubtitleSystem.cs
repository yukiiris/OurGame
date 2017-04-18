using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleSystem : MonoBehaviour
{
    public static bool isSubtitleOn;
    public static Subtitle sub;
    public static Subtitle specialSub;
    // Use this for initialization
    void Start()
    {
        sub = GameObject.FindGameObjectWithTag("Subtitle").GetComponent<Subtitle>();
        specialSub = GameObject.FindGameObjectWithTag("SpecialSubtitle").GetComponent<Subtitle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ShowSubtitle(string title, float delaySeconds = 1f)
    {
        if (delaySeconds < 0.01f) delaySeconds = 1;
        //显示字幕
        sub.ShowSubtitle(title, delaySeconds);
        //
        isSubtitleOn = true;
    }

    public static void ShowSpecialSubtitle(string title, float delaySeconds = 1f)
    {
        if (delaySeconds < 0.01f) delaySeconds = 1;
        //显示字幕
        specialSub.ShowSubtitle(title, delaySeconds);
        //
        isSubtitleOn = true;
    }

    public void HideSubtitle()
    {
        //
        isSubtitleOn = false;
    }
}
