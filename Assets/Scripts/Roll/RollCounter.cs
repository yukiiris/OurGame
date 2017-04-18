using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCounter : MonoBehaviour {
	public int pieceNum = 0;
	public int pieceMax = 1;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pieceNum == pieceMax) {
			rend.enabled = true;
		}
		else {
			rend.enabled = false;
		}
		
	}
}
