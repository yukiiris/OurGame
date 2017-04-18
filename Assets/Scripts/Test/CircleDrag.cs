using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrag : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (Vector3.zero,relativePos);
		transform.rotation = rotation;
	}
}
