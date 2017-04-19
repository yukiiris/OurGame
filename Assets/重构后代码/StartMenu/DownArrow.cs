using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : MonoBehaviour {
    private void OnMouseDown()
    {
        if (StartMenu.nowCard < 5)
        {
            StartMenu.nowCard += 1;
        }
    }
}
