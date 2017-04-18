using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLineLast : MonoBehaviour {
	public Vector3 lastPos = new Vector3 (0, 0, 0);
	public int num = 0;
	public int max = 2;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (num == max) {
			rend.enabled = true;
		}
	}
}
