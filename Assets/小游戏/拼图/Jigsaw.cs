using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jigsaw : MonoBehaviour {

    JigsawManager manager;
    public int place = 0;
    public int ID = 0;
    // Use this for initialization
    void Start () {
        manager = GetComponentInParent<JigsawManager>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnMouseDown()
    {
        if ((manager.blank - place) == 1 || (manager.blank - place) == -1)
        {
            GetComponent<Transform>().position += new Vector3((manager.blank - place) * 1.6f, 0, 0);
            int a = manager.blank;
            manager.nowArray[manager.blank] = ID;
            manager.nowArray[place] = 8;
            manager.blank = place;
            place = a;
        }
        else if ((manager.blank - place) == 3 || (manager.blank - place) == -3)
        {
            GetComponent<Transform>().position += new Vector3(0, (manager.blank - place) / 3 * -1.6f, 0);
            int a = manager.blank;
            manager.nowArray[manager.blank] = ID;
            manager.nowArray[place] = 8;
            manager.blank = place;
            place = a;
        }
    }

    private void OnMouseUp()
    {
        //Win();
        if (manager.Win())
        {

        }
    }
}
