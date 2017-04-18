using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCounter : MonoBehaviour {
	public int max = 1;
	public int num = 0;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(num==max){
			rend.enabled = true;
		}
	}
}
