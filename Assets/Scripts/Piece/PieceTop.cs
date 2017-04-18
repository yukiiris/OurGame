using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTop : MonoBehaviour {
	public PieceCounter counter;
	private PieceTop top;
	private PieceBottom bottom;
	private Drag drag;
	private bool ifUp=false;
	public float dis = 0.05f;
	// Use this for initialization
	void Start () {
		top = GetComponent<PieceTop> ();
		drag = GetComponent<Drag> ();
		bottom =gameObject.GetComponentInParent<PieceBottom> ();

	}
	void OnMouseUp()
	{
		ifUp = true;
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position,bottom.myPos)<dis&&ifUp==true) {
			drag.enabled = false;
			for (;transform.position!=bottom.myPos;) {
				transform.position=bottom.myPos;
			}
			top.enabled = false;
			counter.num++;
		}
	}
}
