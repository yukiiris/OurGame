using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtectorWithPlayer : MonoBehaviour {

    Rigidbody2D rigi;
    public Transform trans;
    public NPC protector;
    public GameObject g;
    public static bool isTalk = true;

	// Use this for initialization
	void Start () {
        rigi = GetComponent<Rigidbody2D>();
        if (isTalk)
        {
           // trans.position = new Vector3(4, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!isTalk)
        {
            if (System.Math.Abs(Player.current.GetXPosition() - rigi.position.x) > 3)
            {
                if (System.Math.Abs(rigi.position.x - Player.current.GetXPosition()) > 2)
                {
                    protector.leg.MoveTo(Player.current.GetXPosition() + 2 * trans.localScale.x);
                }
            }
        }
        else
        {
            StartCoroutine(Performance());
        }
	}

    public IEnumerator Performance()
    {
        yield return new WaitForSeconds(1);
        string word = "你需要我的时候，我就会出现";
        if (isTalk)
        {
            g.SetActive(true);
            protector.leg.MoveTo(6);
            yield return new WaitForSeconds(0.5f);
            LogSystem.Speak(word, protector);
            protector.leg.MoveTo(6);
        }
        //isTalk = false;
    }
}
