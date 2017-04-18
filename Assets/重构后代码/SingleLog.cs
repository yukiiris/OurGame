using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleLog : MonoBehaviour {
    TextMesh t;
    public Transform middle;
    public Transform up;
    Fade[] flist;
    private void Start()
    {
        flist = GetComponentsInChildren<Fade>();
        for (int i = 0; i < flist.Length; i++) flist[i].FadeIn(0.2f,false);
    }
    public void AutoFix(string text)
    {
        t = GetComponentInChildren<TextMesh>();
        string s;
        int line = LogSystem.text格式化(text, out s);
        t.text = s;
        middle.position += new Vector3(0, 0.25f * line, 0);
        middle.localScale = new Vector3(1, line+1, 1);
        up.position += new Vector3(0, 0.5f * line, 0);

        Leg leg = GetComponentInParent<Leg>();
        if (leg!=null&&leg.transform.localScale.x < 0)
        {
            Vector3 ss = transform.localScale;
            ss.x *= -1;
            transform.localScale = ss;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
        {
            LogSystem.EndSpeak(this);
        }
    }
    public void Disappear()
    {
        StartCoroutine(disappear());
    }
    IEnumerator disappear()
    {
        for (int i = 0; i < flist.Length; i++) flist[i].Disappear();
        Destroy(GetComponent<Collider>());
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
