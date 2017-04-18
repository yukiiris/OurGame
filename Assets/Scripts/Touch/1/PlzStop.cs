using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlzStop : MonoBehaviour {
	public string words="这里好像有堵看不见的墙";
	public Touch touch;
	private bool a = true;
	// Use this for initialization
	void Start () {
		touch = GetComponent<Touch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (touch.isTouched == true&&a==true) {
			SubtitleSystem.ShowSubtitle(words);
			a = false;
		}
		else if(touch.isTouched==false&&a==false){
			a=true;
		}

	}
}
