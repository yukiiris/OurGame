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
        Camera.main.transform.position = (Vector3)((Vector2)transform.position) + Vector3.back * 10;
		yield return new WaitForSecondsRealtime (2f);
		for (int i = 0; i < transform.childCount-1; i++) {
			transform.GetChild (i).gameObject.SetActive (false);
			transform.GetChild (i + 1).gameObject.SetActive (true);
			yield return new WaitForSecondsRealtime (0.2f);
		}
		yield return new WaitForSecondsRealtime (2f);
		GameSystem.IEnded ();
        Transform t = Player.current.GetComponentInParent<Leg>().transform;
        Vector3 v = t.position;
        v.x = 7;
        t.position = v;
        SceneChanger.Change("C1S4", "C1S5", "突然我从床上惊醒，天已经亮了。", 3f);
		yield return null;
	}
}
