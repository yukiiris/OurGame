using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    public GameObject g;
    public GameObject bk1;
    public GameObject bk2;
    public GameObject bk3;
    
    public IEnumerator flash1()
    {
        float t = 1.0f/11;
        g.SetActive(false);
        bk1.SetActive(true);
        Fade.FadeIn(bk1, 0.1f);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(true);
        Fade.FadeIn(g,0.1f);
        bk1.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(false);
        bk2.SetActive(true);
        Fade.FadeIn(bk2, 0.1f);
        yield return new WaitForSeconds(2 * t);
        g.SetActive(true);
        Fade.FadeIn(g, 0.1f);
        yield return new WaitForSeconds(3 * t);
        bk2.SetActive(false);
        g.SetActive(false);
        bk3.SetActive(true);
        Fade.FadeIn(bk3, 0.1f);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(true);
        Fade.FadeIn(g, 0.1f);
        yield return new WaitForSeconds(2 * t);
        bk3.SetActive(false);
        g.SetActive(false);
        bk1.SetActive(true);
        Fade.FadeIn(bk1, 0.1f);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(true);
        Fade.FadeIn(g, 0.1f);
        bk1.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(false);
        bk2.SetActive(true);
        Fade.FadeIn(bk2, 0.1f);
        yield return new WaitForSeconds(2 * t);
        g.SetActive(true);
        Fade.FadeIn(g, 0.1f);
        bk2.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(false);
        bk3.SetActive(true);
        Fade.FadeIn(bk3, 0.1f);
        yield return new WaitForSeconds(3 * t);
        bk3.SetActive(false);
        g.SetActive(true);
        Fade.FadeIn(g, 0.1f);
        yield return new WaitForSeconds(2 * t);
        g.SetActive(false);
    }

    public  IEnumerator flash(int t = 3, float f = 0.1f)
    {
        for ( ; t > 0; t--)
        {
            g.SetActive(false);
            yield return new WaitForSeconds(f);
            g.SetActive(true);
            yield return new WaitForSeconds(f);
        }
    }
}
