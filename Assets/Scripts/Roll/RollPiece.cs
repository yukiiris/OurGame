using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollPiece : MonoBehaviour {
	private Transform tran;
	public RollCounter counter;
	// Use this for initialization
	void Start () {
		tran = GetComponent<Transform> ();
		if (tran.rotation.z == 0) {
			counter.pieceNum++;
		}
	}

	void OnMouseDown(){
		transform.Rotate(0,0,90);
		if (tran.rotation.z == 0) {
			counter.pieceNum++;
		}
		if (tran.rotation==Quaternion.Euler(0,0,90)||tran.rotation==Quaternion.Euler(0,0,450)) {
			counter.pieceNum--;
		}	
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
