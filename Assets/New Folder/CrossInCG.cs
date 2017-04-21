using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossInCG : MonoBehaviour {

    public GameObject obj;
    public GameObject black;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        black.SetActive(false);
        obj.SetActive(false);
    }
}
