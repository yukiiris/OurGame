using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour {

    GameObject startButtom;

	// Use this for initialization
	void Start () {
        startButtom = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        MyCamera.isFixing = true;
        GameObject.FindGameObjectWithTag("music").GetComponent<RectTransform>().position = new Vector3(-100, -100, 0);
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("C1S1", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("标题界面");
    }
}
