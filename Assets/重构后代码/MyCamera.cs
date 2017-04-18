using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
	public static Vector3 focusPoint;//the camera focus
	Vector3 fixedFocusPoint;//to shake the screen when you move your mouse
	public float shakePosition=0.002f;//the range camera shakes
	public float smoothRate=0.2f;
    public static Vector3 screenCenter;
    public static bool isFixing=true;
    
	// Use this for initialization
	void Start () {
		FocusTo (transform.position);
        screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2,0);
    }


	// Update is called once per frame
	void Update () {
		if(isFixing)Fix ();
	}

	public void Fix(){
		fixedFocusPoint = focusPoint + (Input.mousePosition-screenCenter) * shakePosition;
        transform.position = (fixedFocusPoint - transform.position) * smoothRate + transform.position;
    }

	public static void FocusTo(Vector3 f){
		focusPoint = new Vector3 (f.x, f.y, -10);
	}
}