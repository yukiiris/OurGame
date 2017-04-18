using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re : MonoBehaviour {
	public GameObject prefab;
	public GameObject first;
	private GameObject child;
	private Vector3 pos=new Vector3(0,0,0);
	private Quaternion qua=new Quaternion(0,0,0,0);
	// Use this for initialization
	void Start () {
		pos = first.transform.position;
		qua = first.transform.rotation;
	}
	void OnMouseDown(){
		for (int i = 0; i < transform.childCount; i++) {  
			Destroy (transform.GetChild (i).gameObject);  
		} 
		child=Instantiate (prefab,pos,qua);
		child.transform.parent = gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
