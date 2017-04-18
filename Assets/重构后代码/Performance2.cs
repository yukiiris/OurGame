using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Performance2 : MonoBehaviour {

    public GameObject protector;
    public NPC npc;
    public static bool isTalk = true;
	// Use this for initialization
	void Start () {
        //StartCoroutine(Performance());
	}
	
	// Update is called once per frame
	void Update () {
        if (isTalk)
        {
            SceneManager.LoadScene("GameScene1", LoadSceneMode.Additive);
        }
        isTalk = false;
    }

    public IEnumerator Performance()
    {
        if (isTalk)
        {
            SceneManager.LoadScene("GameScene1", LoadSceneMode.Additive);
            yield return 0;
        }
        isTalk = false;
    }
}
