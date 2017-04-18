using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGButtom : MonoBehaviour {

    public GameObject collection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //collection.SetActive(true);
        SceneManager.LoadScene("CG", LoadSceneMode.Additive);
    }
}
