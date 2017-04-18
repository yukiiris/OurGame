using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Falling : MonoBehaviour {
	public Touch touch;
	// Use this for initialization
	void Start () {
		touch = GetComponent<Touch> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(touch.isTouched==true){
//			SceneManager.LoadScene ("MainScene");
//			SceneManager.LoadScene ("PlayerScene");
			SceneManager.LoadScene ("C1S2",LoadSceneMode.Additive);
			SceneManager.UnloadSceneAsync ("C1S1");
		}
	}
}
