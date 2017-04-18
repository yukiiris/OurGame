using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySwitchDis : MonoBehaviour {
	private MySwitch mySwitch;
	public GameObject something;
	// Use this for initialization
	void Start () {
		mySwitch = GetComponent<MySwitch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mySwitch.mySwitch == true) {
			something.SetActive (false);
		}
	}
}
