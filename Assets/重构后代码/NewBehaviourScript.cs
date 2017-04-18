using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject heiqizi;
	// Use this for initialization
	void Start () {
        GameObject.Instantiate(heiqizi, new Vector3(0, 0, 0), Quaternion.identity, transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
