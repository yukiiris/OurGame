using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
	public bool isTouched = false;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerStay2D(){
		isTouched = true;
	}
	void OnTriggerExit2D(Collider2D collider){
		isTouched = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
