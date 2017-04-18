using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimaStrangeRoom : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine (MyCoroutine());
	}
	
	// Update is called once per frame
//	void Update () {
//		for (int i = 0; i < transform.childCount-1; i++) {
//			transform.GetChild (i).gameObject.active = false;
//			transform.GetChild (i + 1).gameObject.active = true;
//			Debug.Log (i);
//		}
//
//	}
	IEnumerator MyCoroutine(){
		GameSystem.IStarted ();
		yield return new WaitForSecondsRealtime (2f);
		for (int i = 0; i < transform.childCount-1; i++) {
			transform.GetChild (i).gameObject.SetActive (false);
			transform.GetChild (i + 1).gameObject.SetActive (true);
			yield return new WaitForSecondsRealtime (0.2f);
		}
		yield return new WaitForSecondsRealtime (2f);
		GameSystem.IEnded ();
		SceneManager.LoadScene ("C1S5",LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("C1S4");
		yield return null;
	
	}
}
