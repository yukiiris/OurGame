using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWithPlayer : MonoBehaviour {
    public float moveRange=6;
    public float stayRange=1;
    public float moveSpeed = 0.08f;
    float tempRange;
    // Use this for initialization
    void Start () {
        tempRange = moveRange;
    }
	
	// Update is called once per frame
	void Update () {
        if (System.Math.Abs(Player.current.GetXPosition() - MyCamera.focusPoint.x) > tempRange)
        {
            tempRange = stayRange;
            MyCamera.FocusTo(MyCamera.focusPoint + new Vector3(moveSpeed * (Player.current.GetXPosition() > MyCamera.focusPoint.x ? 1 : -1), 0, 0));
        }else
        {
            tempRange = moveRange;
        }
    }
}
