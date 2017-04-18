using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySwitch : MonoBehaviour {
	public bool mySwitch = false;
	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){
		mySwitch = !mySwitch;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
