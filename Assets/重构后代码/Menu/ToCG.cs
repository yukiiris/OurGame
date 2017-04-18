using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCG : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        SceneManager.LoadScene("CG", LoadSceneMode.Additive);
        GameObject.FindGameObjectWithTag("music").GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
    }
}
