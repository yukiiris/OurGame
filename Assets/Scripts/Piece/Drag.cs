using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	private Vector3 mousePos;
	//private Vector3 thisPos;
	//private Vector3 disPos;
	// Use this for initialization
	void Start () {
		//thisPos = Camera.main.WorldToScreenPoint (transform.position);
		//disPos = thisPos - transform.position;
		mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,10);
	}
	void OnMouseDrag(){
		transform.position = Camera.main.ScreenToWorldPoint (mousePos);
	}
	// Update is called once per frame
	void Update () {
		mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,10);
	}
}
