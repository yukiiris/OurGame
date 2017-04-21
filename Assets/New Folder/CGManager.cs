using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGManager : MonoBehaviour {

    public bool[] isLock = { true };

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Unlock(int i)
    {
        isLock[0]= false;
    }
}
