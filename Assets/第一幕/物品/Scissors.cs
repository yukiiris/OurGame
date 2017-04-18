using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour {
	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Handle.activeScissors) {
			gameObject.SetActive (false);
		}
	}
}
