using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 放动画 : MonoBehaviour {
    public static bool isMove;
	void Update () {
		if (isMove)
        {
           Player.animator.SetBool("isMove", true);
        }
	}
}
