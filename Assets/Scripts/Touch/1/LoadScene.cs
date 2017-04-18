using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public Touch touch;
	public string scene1;
	// Use this for initialization
	void Start () {
		touch = GetComponent<Touch> ();
	}

	// Update is called once per frame
	void Update () {
		if(touch.isTouched==true){
			SceneManager.LoadScene (scene1,LoadSceneMode.Additive);
			gameObject.SetActive(false);
		}
	}
}
