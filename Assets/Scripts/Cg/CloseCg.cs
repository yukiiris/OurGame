using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDown(){
		GameSystem.IEnded ();
		transform.parent.gameObject.SetActive (false);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
