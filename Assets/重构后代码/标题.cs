using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 标题 : MonoBehaviour
{
    public GameObject title;
    public GameObject titleback;
    public GameObject titlefront;
    public GameObject bug;
    public static bool isStart = false;
    public Rigidbody2D rigi;
    public GameObject cover;
    public float x;
    public float y;
    // Use this for initialization
    void Start()
    {
        MyCamera.isFixing = false;
        StartCoroutine(Title());
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector2(x, y);
    }

    public IEnumerator Title()
    {
        if (isStart)
        {
            cover.SetActive(true);
            bug.SetActive(true);
            titleback.SetActive(true);
            Fade.FadeIn(titleback, 2);
            titlefront.SetActive(true);
            Fade.FadeIn(titlefront, 2);
            yield return 0;
            title.SetActive(true);
            Fade.FadeIn(title, 4);
            yield return new WaitForSeconds(2);
            cover.SetActive(false);
            isStart = false;
        }
        titleback.SetActive(true);
        titlefront.SetActive(true);
        title.SetActive(true);
    }

}
