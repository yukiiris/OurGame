using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    static public string toUnload;
    static public string toLoad;
    static public string Sub;
    static public float delayTime;
    static bool isChanging = false;
    public GameObject black;

    static public void Change(string tounload, string toload,string sub = "",float delaytime= 0.4f)
    {
        if (!isChanging)
        {
            toUnload = tounload;
            toLoad = toload;
            Sub = sub;
            delayTime = delaytime;
            if (delayTime < 0.1f) delayTime = 0.4f;
            SceneManager.LoadScene("过渡场景", LoadSceneMode.Additive);
            isChanging = true;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(ch());
	}
    IEnumerator ch()
    {
        Vector3 temp = Player.current.GetComponentInParent<Leg>().transform.position;
        black.transform.position = (Vector2)Camera.main.transform.position;
        Fade.FadeIn(black);
        yield return new WaitForSeconds(0.5f);
        SceneManager.UnloadSceneAsync(toUnload);
        SubtitleSystem.ShowSpecialSubtitle(Sub, delayTime);
        yield return new WaitForSeconds(delayTime + 1f);
        SceneManager.LoadScene(toLoad,LoadSceneMode.Additive);
        Player.current.GetComponentInParent<Leg>().transform.position = temp;
        Fade.Disappear(black);
        yield return new WaitForSeconds(0.3f);
        isChanging = false;
        SceneManager.UnloadSceneAsync("过渡场景");
    }
}
