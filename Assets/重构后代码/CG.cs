using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG : MonoBehaviour {

    public int ID = 0;
    public GameObject bigPicture;
    public GameObject cross;
    SpriteRenderer r;
    public CGManager manager;

	// Use this for initialization
	void Start () {
        r = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update () {
        if (!manager.isLock[ID])
        {
            r.color = new Color(1, 1, 1, 1);
        }
	}

    private void OnMouseUp()
    {
        if (!manager.isLock[0])
        {
            cross.SetActive(true);
            bigPicture.SetActive(true);
        }
    }
}
