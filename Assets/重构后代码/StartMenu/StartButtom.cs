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
        SceneChanger.Change("标题界面", "C1S1", "我不知道发生了什么", 3.5f);
    }
}
