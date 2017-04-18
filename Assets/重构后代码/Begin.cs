using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    public Flash flash;
    public GameObject sky;
    public GameObject black;
    public GameObject background;
    public GameObject bug;
    public GameObject titleScene1;
    public GameObject titleScene2;
    public GameObject titleScene3;
    public GameObject titleScene4;
    public GameObject titleScene5;
    public GameObject titleScene6;
    public GameObject titleScene7;
    public float speed;
    Transform trans;
    // Use this for initialization
    void Start () {
        MyCamera.isFixing = false;
        StartCoroutine(begin());
    }
	
	// Update is called once per frame
	void Update () {
        if(trans!=null)trans.position += new Vector3(-speed, 0, 0);
	}

    IEnumerator begin()
    {
        float t = 2.725f;
        yield return Words1();//第一句话
        yield return new WaitForSeconds(9.29f);
        yield return flash.flash1();//闪烁
        sky.SetActive(true);//天空
        yield return new WaitForSeconds(2);
        background.SetActive(false);
        Fade.FadeOut(sky, 2);//天空消失
        yield return new WaitForSeconds(3);
        yield return Words2();
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
        titleScene1.SetActive(true);
        Fade.FadeIn(titleScene1);
        放动画.isMove = true;
        trans = titleScene1.transform;
        yield return new WaitForSeconds(t);
        titleScene1.SetActive(false);
        titleScene2.SetActive(true);
        trans = titleScene2.transform;
        yield return new WaitForSeconds(t);
        titleScene3.SetActive(true);
        titleScene2.SetActive(false);
        trans = titleScene3.transform;
        yield return new WaitForSeconds(t);
        titleScene3.SetActive(false);
        titleScene4.SetActive(true);
        trans = titleScene4.transform;
        yield return new WaitForSeconds(t);
        titleScene4.SetActive(false);
        titleScene5.SetActive(true);
        trans = titleScene5.transform;
        yield return new WaitForSeconds(t);
        titleScene5.SetActive(false);
        titleScene6.SetActive(true);
        trans = titleScene6.transform;
        yield return new WaitForSeconds(t);
        titleScene6.SetActive(false);
        titleScene7.SetActive(true);
        trans = titleScene7.transform;
        yield return new WaitForSeconds(t);
        放动画.isMove = false;
        titleScene1.SetActive(false);
        titleScene3.SetActive(false);
        titleScene4.SetActive(false);
        titleScene5.SetActive(false);
        titleScene6.SetActive(false);
        Fade.FadeOut(titleScene7, 1);
        SceneManager.UnloadSceneAsync("PlayerScene");
        yield return new WaitForSeconds(2);
        titleScene7.SetActive(false);
        yield return Words3();
        yield return new WaitForSeconds(3);
        yield return Words4();
        yield return new WaitForSeconds(3);
        标题.isStart = true;
        SceneManager.LoadScene("标题界面", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("片头");
    }

    public IEnumerator Words1()
    {
        yield return new WaitForSeconds(2.8f);
        SubtitleSystem.ShowSpecialSubtitle("人们都喜欢和平美好的生活", 4f);
    }

    public IEnumerator Words2()
    {
        yield return 0;
        SubtitleSystem.ShowSpecialSubtitle("没有担忧、没有痛苦、没有离别", 4.5f);
    }

    public IEnumerator Words3()
    {
        yield return new WaitForSeconds(1);
        SubtitleSystem.ShowSpecialSubtitle("就像我所拥有的那样", 3f);
    }

    public IEnumerator Words4()
    {
        yield return new WaitForSeconds(1);
        SubtitleSystem.ShowSpecialSubtitle("直到······", 4f);
    }
}
