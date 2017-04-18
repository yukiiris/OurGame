using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 流程 : MonoBehaviour {

	// Use this for initialization
	void Start () {
       SceneManager.LoadSceneAsync("片头", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
