using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeSence : MonoBehaviour {
	public Touch touch;
	public string sceneToLoad;
	public string sceneToUnLoad;
    public string sub;
    public float delaytime;
	// Use this for initialization
	void Start () {
		touch = GetComponent<Touch> ();
	}

	// Update is called once per frame
	void Update () {
		if(touch.isTouched==true){
            SceneChanger.Change(sceneToUnLoad, sceneToLoad, sub, delaytime);
		}
	}
}
