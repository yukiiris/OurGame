using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLineNote : MonoBehaviour {
	public Vector3 myPos = new Vector3(0,0,0);
	private Renderer rend;
	public bool ifChange = false;
	public bool ifLink = false;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.material.color = Color.gray;
		myPos = transform.position;
	}
	// Update is called once per frame
	void Update () {
		if (ifChange == true) {
			rend.material.color = Color.white;
		}
	else if (ifChange == false) {
		rend.material.color = Color.gray;
	}
}
}
