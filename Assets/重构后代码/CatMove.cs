using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour {
    public NPC cat;
    public AudioSource miao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        miao.Play();
        cat.leg.MoveTo(52);
        yield return new WaitForSeconds(1f);
        cat.leg.MoveTo(54);
    }
}
