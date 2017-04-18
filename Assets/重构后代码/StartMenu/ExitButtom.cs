using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtom : MonoBehaviour {

    GameObject exitButtom;

    // Use this for initialization
    void Start () {
        exitButtom = GetComponent<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
