using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBrake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnMouseDown(){
		EBrake.brakeIsOn = !EBrake.brakeIsOn;
	
	}
	// Update is called once per frame
	void Update () {
	}
}
