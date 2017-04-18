using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 获胜按钮 : MonoBehaviour {

    private void OnMouseUp()
    {
        GameSystem.IWin();
        Destroy(GetComponentInParent<充数小游戏本体>().gameObject);
    }
}
