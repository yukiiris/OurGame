using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCounter : MonoBehaviour {

	public int lightNum = 0;
	public int lightMax = 1;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lightNum == lightMax) {
			rend.enabled = true;
		}
	}
}
