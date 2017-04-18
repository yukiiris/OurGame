using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 道具栏上的叉叉 : MonoBehaviour {
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            ItemSystem.current.HideItemBlank();
        }
    }
}
