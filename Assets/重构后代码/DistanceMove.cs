using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMove : MonoBehaviour {
    Vector3 local;
    Vector3 center;
    public float distanceRate=0.5f;
	// Use this for initialization
	void Start () {
        local = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        center = new Vector3(Camera.main.ScreenToWorldPoint(MyCamera.screenCenter).x, Camera.main.ScreenToWorldPoint(MyCamera.screenCenter).y, 0);
        transform.position = local +  center* distanceRate;
	}
}
