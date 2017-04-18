using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleLight : MonoBehaviour {
	public LightCounter  counter;
	public LightPuzzleLight lightUp;
	public LightPuzzleLight lightDown;
	public LightPuzzleLight lightRight;
	public LightPuzzleLight lightLeft;
	public bool ifOn = true;
	private bool ifChange = false;
	private bool ifClick = false;
	private Renderer rend;
	public bool ifUp = false;
	public bool ifDown= false;
	public bool ifRight= false;
	public bool ifLeft= false;



	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}

	void OnMouseDown(){
		ifClick = true;
	}

	// Update is called once per frame
	void Update () {
		if (ifClick) {
			ifChange = true;
			if (ifUp==true) {
				lightUp.ifChange = true;
			}
			if (ifDown==true) {
				lightDown.ifChange = true;
			}
			if (ifRight==true) {
				lightRight.ifChange = true;
			}
			if (ifLeft==true) {
				lightLeft.ifChange = true;
			}
			ifClick = false;
		}
		if (ifChange) {
			if (ifOn) {
				ifOn = false;
				--counter.lightNum;
			}
			else {
				ifOn = true;
				++counter.lightNum;
			}
			rend.enabled = !rend.enabled;
			ifChange = false;
		}
	}
}
