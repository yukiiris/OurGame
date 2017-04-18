using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    public GameObject g;
    public GameObject bk1;
    public GameObject bk2;
    public GameObject bk3;

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

    public IEnumerator flash1()
    {
        float t = 1.0f/11;
        g.SetActive(false);
        bk1.SetActive(true);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(true);
        bk1.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(false);
        bk2.SetActive(true);
        yield return new WaitForSeconds(2 * t);
        g.SetActive(true);
        bk2.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        bk3.SetActive(true);
        yield return new WaitForSeconds(3 * t);
        bk3.SetActive(false);
        g.SetActive(true);
        yield return new WaitForSeconds(2 * t);
        bk1.SetActive(true);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(true);
        bk1.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        g.SetActive(false);
        bk2.SetActive(true);
        yield return new WaitForSeconds(2 * t);
        g.SetActive(true);
        bk2.SetActive(false);
        yield return new WaitForSeconds(3 * t);
        bk3.SetActive(true);
        yield return new WaitForSeconds(3 * t);
        bk3.SetActive(false);
        g.SetActive(true);
        yield return new WaitForSeconds(2 * t);
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
