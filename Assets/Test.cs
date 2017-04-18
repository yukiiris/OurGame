using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ItemSystem.current.isShowing)
            {
                ItemSystem.current.HideItemBlank();
            }
            else
            {
                ItemSystem.current.ShowItemBlank();
            }
        }
    }
}
