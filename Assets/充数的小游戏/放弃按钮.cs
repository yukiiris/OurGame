using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 放弃按钮 : MonoBehaviour {
    private void OnMouseUp()
    {
        GameSystem.IEnded();
        Destroy(GetComponentInParent<充数小游戏本体>().gameObject);
    }
}
