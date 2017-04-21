using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : MonoBehaviour {

    private void OnMouseDown()
    {
        if (StartMenu.nowCard > 0)
        {
            StartMenu.nowCard -= 1;
        }
    }
}
