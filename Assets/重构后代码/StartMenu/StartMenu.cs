using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public static int[] card = { 0, 1, 2, 3, 4 };
    public static int nowCard = 0;
    public GameObject start;
    public GameObject exit;
    public GameObject options;
    public GameObject gallery;
    public GameObject cont;
    static GameObject now;
    // Use this for initialization
    void Start()
    {
        now = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowCard == 0)
        {
            now.SetActive(false);
            //Fade.FadeOut(now);
            start.SetActive(true);
            now = start;
        }
        else if (nowCard == 1)
        {
            now.SetActive(false);
            //Fade.FadeOut(now);
            options.SetActive(true);
            now = options;
        }
        else if (nowCard == 2)
        {
            now.SetActive(false);
            //Fade.FadeOut(now);
            gallery.SetActive(true);
            now = gallery;
        }
        else if (nowCard == 3)
        {
            now.SetActive(false);
            //Fade.FadeOut(now);
            cont.SetActive(true);
            now = cont;
        }
        else
        {
            now.SetActive(false);
            //Fade.FadeOut(now);
            exit.SetActive(true);
            now = exit;
        }
    }
}