using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtom : MonoBehaviour {

    GameObject menuButtom;
    RectTransform music;
	// Use this for initialization
	void Start () {
        menuButtom = GetComponent<GameObject>();
        music = GameObject.FindGameObjectWithTag("music").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        CrossInCGSystem.isStart = false;
        SceneManager.LoadScene("菜单界面", LoadSceneMode.Additive);
        music.position = new Vector3(250, 330, 0);
    }
}
