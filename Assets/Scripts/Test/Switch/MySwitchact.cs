using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySwitchact : MonoBehaviour {
	public MySwitch mySwitch;
	public GameObject object1;
	public GameObject object2;
	// Use this for initialization
	void Start () {
		mySwitch =GetComponent<MySwitch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mySwitch.mySwitch == false) {
			object1.active = true;
			object2.active = false;
		}
		else if(mySwitch.mySwitch==true){
			object1.active = false;
			object2.active = true;
		}
	}
}
