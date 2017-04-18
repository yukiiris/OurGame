using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act : MonoBehaviour {
	public GameObject puzzle;
	// Use this for initialization
	void Start () {
		
	}
	void OnMouseDown(){
		puzzle.active = !puzzle.active;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
